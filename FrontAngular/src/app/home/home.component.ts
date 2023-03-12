import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormControl,
} from '@angular/forms';

import { MessageService } from 'primeng/api';

import { NavalWarRequestService } from '../services/navalwarRequest.service';
import { NavalWarDataStoreService } from '../services/navalwarDataStore.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [MessageService]
})
export class HomeComponent implements OnInit {

  CreateGame!: FormGroup;
  JoinGame!: FormGroup;
  loadingNewGame: boolean = false;

  constructor(private builder: FormBuilder,
    private router: Router,
    private navalWarService: NavalWarRequestService,
    private navalWarDataStoreService: NavalWarDataStoreService,
    private messageService: MessageService) { }

  ngOnInit() {
    this.CreateGame = this.builder.group({
      NameP1: new FormControl('', [Validators.required]),
    });

    this.JoinGame = this.builder.group({
      IdGame: new FormControl('', [Validators.required]),
      NameP2: new FormControl('', [Validators.required]),
    });
  }

  onSubmitCreateGame() {
    this.loadingNewGame = true;
    this.navalWarService
      .CreateGame(this.CreateGame.value)
      .subscribe(
        (data) => {
          this.navalWarDataStoreService.setInfoGame(this.navalWarDataStoreService.requestAnswerToInfoGame(data));
          this.navalWarDataStoreService.setInfoPlayer(this.navalWarDataStoreService.requestAnswerToInfoPlayer(data, 1));
          this.loadingNewGame = false;
          this.router.navigate(['/game', data.idGame, 1]);
        },
        (erreur) => {
        }
      );
    this.CreateGame.reset();
  }



  onSubmitJoinGame() {
    this.navalWarService
      .JoinGame(this.JoinGame.value)
      .subscribe(
        (data) => {
          console.log(data);
          this.navalWarDataStoreService.setInfoGame(this.navalWarDataStoreService.requestAnswerToInfoGame(data));
          this.navalWarDataStoreService.setInfoPlayer(this.navalWarDataStoreService.requestAnswerToInfoPlayer(data, 2));
          this.router.navigate(['/game', data.idGame, 2]);
        },
        (erreur) => {
          this.showError("Erreur", erreur.error);
        }
      );
    this.JoinGame.reset();
  }



  showError(summary : string, detail : string) {
    this.messageService.add({ severity: 'error', summary: summary, detail: detail });
  }


}
