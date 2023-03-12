import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NavalWarRequestService } from '../services/navalwarRequest.service';
import { NavalWarDataStoreService } from '../services/navalwarDataStore.service';
import { InfoPlayer } from '../models/infoPlayer.model';
import { InfoGame } from '../models/infoGame.model';
import { interval } from 'rxjs';
import { GlobalMessage } from '../models/globalMessage.model';



@Component({
  selector: 'app-shoot-game',
  templateUrl: './shoot-game.component.html',
  styleUrls: ['./shoot-game.component.scss'],
})
export class ShootGameComponent implements OnInit {

  gridBoat: any = [];
  gridShoot: any = [];
  infoPlayer!: InfoPlayer;
  infoGame!: InfoGame;

  constructor(
    private navalWarDataStoreService: NavalWarDataStoreService,
    private navalWarRequestService: NavalWarRequestService) { };

  BackToFrondGrid(plateau: any): any {
    let grid = [['', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'], ['1'], ['2'], ['3'], ['4'], ['5'], ['6'], ['7'], ['8'], ['9'], ['10']];

    //console.log(infoPlayer.plateauBoat.plateau);
    //console.log(this.infoPlayer.plateauBoat.plateau);
    //console.log(this.infoPlayer.plateauBoat.boats);

    for (let y = 0; y < 10; y++) {
      for (let x = 0; x < 10; x++) {
        grid[y + 1][x + 1] = plateau[y * 10 + x];
      }
    }

    return grid;

  };


  shot(x: any, y: any): void {
    if (x !== undefined && y !== undefined) {

      this.navalWarRequestService.Shot(x, y, this.infoPlayer.idPlayer, this.infoGame.idGame, this.infoGame.idEnnemy).subscribe(
        (data) => {
          console.log(data);
          this.navalWarDataStoreService.setNewPlateauShot(data.plateauShot);
          this.navalWarDataStoreService.changeIsWinner(data.isWinner);
          this.navalWarDataStoreService.setGlobalErrorMessage({ message: data.reponse, titre: 'Tir', type: (data.isHit ? 'success' : 'info') } as GlobalMessage);
          if(data.isBoatKill){
            this.navalWarDataStoreService.setGlobalErrorMessage({ message: 'Un bateau a été détruit !', titre: 'Félicitation', type: 'custom' } as GlobalMessage);
            console.log("hup");
          }
          
        },
        (error) => {
          this.navalWarDataStoreService.setGlobalErrorMessage({ message: error.error, titre: 'Tir', type: 'error' } as GlobalMessage);
        }
      );
    }
  }

  mainLoop(): void {
    const myInterval = interval(2000);

    // Abonner au flux d'intervalle
    myInterval.subscribe(() => {
      // 
      this.navalWarRequestService.GetAuTourDeQui(this.infoGame.idGame).subscribe(
        (data) => {
          this.navalWarDataStoreService.changeAuTourDe(data);
        });
    });
  }


  updatePlateauBoat(): void {
    this.navalWarRequestService.GetPlateauBoat(this.infoPlayer.idPlayer).subscribe(
      (data) => {
        //console.log(data);
        this.navalWarDataStoreService.setNewPlateauBoat(data);
      }
    );
  }


  ngOnInit(): void {
    this.navalWarDataStoreService.onInfoPlayerChange().subscribe(
      (suggestion) => {
        this.infoPlayer = suggestion;
        this.gridBoat = this.BackToFrondGrid(this.infoPlayer.plateauBoat.plateau);
        this.gridShoot = this.BackToFrondGrid(this.infoPlayer.plateauShot.plateau);
      }
    );


    this.navalWarDataStoreService.onInfoGameChange().subscribe(
      (suggestion) => {
        this.infoGame = suggestion
        this.updatePlateauBoat();
      }

    );

    this.mainLoop();

  }




}
