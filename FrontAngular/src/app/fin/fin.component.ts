import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NavalWarRequestService } from '../services/navalwarRequest.service';
import { NavalWarDataStoreService } from '../services/navalwarDataStore.service';
import { InfoPlayer } from '../models/infoPlayer.model';
import { InfoGame } from '../models/infoGame.model';



@Component({
  selector: 'app-fin',
  templateUrl: './fin.component.html',
  styleUrls: ['./fin.component.scss']
})
export class FinComponent implements OnInit {

  infoGame!: InfoGame;
  infoPlayer!: InfoPlayer;
  chargement: number = 0;
  gridPlayer: any = [];
  gridEnnemy: any = [];

  constructor(
    private navalWarDataStoreService: NavalWarDataStoreService,
    private navalWarRequestService: NavalWarRequestService) { };


  BackToFrondGrid(plateau: any): any {
    let grid = [['', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'], ['1'], ['2'], ['3'], ['4'], ['5'], ['6'], ['7'], ['8'], ['9'], ['10']];

    //console.log(infoPlayer.plateauBoat.plateau);
    console.log(this.infoPlayer.plateauBoat.plateau);
    console.log(this.infoPlayer.plateauBoat.boats);

    for (let y = 0; y < 10; y++) {
      for (let x = 0; x < 10; x++) {
        grid[y + 1][x + 1] = plateau[y * 10 + x];
      }
    }

    return grid;

  };

  ngOnInit(): void {
    this.navalWarDataStoreService.onInfoPlayerChange().subscribe(
      (suggestion) => {
        this.infoPlayer = suggestion;
      }
    );
    this.navalWarDataStoreService.onInfoGameChange().subscribe(
      suggestion => this.infoGame = suggestion);


    this.gridPlayer = this.BackToFrondGrid(this.infoPlayer.plateauBoat.plateau);
    this.navalWarRequestService.GetPlateauBoat(this.infoGame.idEnnemy).subscribe(
      (data) => {
        this.gridEnnemy = this.BackToFrondGrid(data.plateau);
        this.chargement += 1;
      }
    );
    this.navalWarRequestService.GetPlateauBoat(this.infoPlayer.idPlayer).subscribe(
      (data) => {
        this.gridPlayer = this.BackToFrondGrid(data.plateau);
        this.chargement += 1;
      }
    );
  }


}
