import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NavalWarRequestService } from '../services/navalwarRequest.service';
import { NavalWarDataStoreService } from '../services/navalwarDataStore.service';
import { InfoPlayer } from '../models/infoPlayer.model';
import { InfoGame } from '../models/infoGame.model';
import { interval } from 'rxjs';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { GlobalMessage } from '../models/globalMessage.model';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss'],
  providers: [MessageService]
})
export class GameComponent implements OnInit {

  infoGame!: InfoGame;
  infoPlayer!: InfoPlayer;
  loading: boolean = true;


  constructor(private route: ActivatedRoute,
    private navalWarDataStoreService: NavalWarDataStoreService,
    private navalWarRequestService: NavalWarRequestService,
    private router: Router,
    private messageService: MessageService) { };


  getGameInfo(idGame: number, player1or2: number): void {
    this.navalWarRequestService
      .RecupDataGame(idGame, player1or2)
      .subscribe(
        (data) => {
          this.navalWarDataStoreService.setInfoGame(this.navalWarDataStoreService.requestAnswerToInfoGame(data));
          this.navalWarDataStoreService.setInfoPlayer(this.navalWarDataStoreService.requestAnswerToInfoPlayer(data, player1or2));
          this.mainLoop();
        },
        (erreur) => {
          console.log(erreur);
          this.router.navigate(['/']);
        }
      );
  }


  ngOnInit(): void {
    let idGame = this.route.snapshot.paramMap.get('idGame');
    let player1or2 = this.route.snapshot.paramMap.get('player1or2');
    this.navalWarDataStoreService.onInfoPlayerChange().subscribe(suggestion => this.infoPlayer = suggestion);
    this.navalWarDataStoreService.onInfoGameChange().subscribe(suggestion => this.infoGame = suggestion);
    this.navalWarDataStoreService.onGlobalErrorMessageChange().subscribe(suggestion => this.showMessage(suggestion.titre, suggestion.message, suggestion.type));
    if (this.infoGame.idGame == undefined || this.infoPlayer.idPlayer == undefined || this.infoGame.idGame != Number(idGame) || this.infoPlayer.player1or2 != Number(player1or2)) {
      this.getGameInfo(Number(idGame), Number(player1or2));
    }
    else {
      this.mainLoop();
      console.log("pas de changement");
    }

  }

  mainLoop(): void {
    this.loading = false;
    const myInterval = interval(2000);

    // Abonner au flux d'intervalle
    myInterval.subscribe(() => {
      
      // si la partie n'est pas finie on recupere l'état sinon plus besoin
      if(this.infoGame.etatGame !== 2){
      this.navalWarRequestService.GetEtatGame(this.infoGame.idGame).subscribe(
        (data) => {
          this.navalWarDataStoreService.changeEtatGame(data);
          //console.log("etat game changé: " + data);
        });
      }
    });


  }

  showMessage(summary: string, detail: string, type: string) {
    this.messageService.add({ severity: type, summary: summary, detail: detail });
  }

}
