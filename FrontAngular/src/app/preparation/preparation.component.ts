import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NavalWarRequestService } from '../services/navalwarRequest.service';
import { NavalWarDataStoreService } from '../services/navalwarDataStore.service';
import { InfoPlayer } from '../models/infoPlayer.model';
import { InfoGame } from '../models/infoGame.model';
import { GlobalMessage } from '../models/globalMessage.model';

@Component({
  selector: 'app-preparation',
  templateUrl: './preparation.component.html',
  styleUrls: ['./preparation.component.scss'],
})
export class PreparationComponent implements OnInit {

  infoGame!: InfoGame;
  infoPlayer!: InfoPlayer;
  loading: boolean = true;
  grid: any = [];
  bateaux: any = [];
  isVertical: boolean = false;
  bateauAposer !: any;
  deleteBoat: boolean = false;


  constructor(
    private navalWarDataStoreService: NavalWarDataStoreService,
    private navalWarRequestService: NavalWarRequestService) { };


  BackToFrondGrid(): any {
    let grid = [['', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'], ['1'], ['2'], ['3'], ['4'], ['5'], ['6'], ['7'], ['8'], ['9'], ['10']];

    //console.log(infoPlayer.plateauBoat.plateau);
    //console.log(this.infoPlayer.plateauBoat.plateau);
    //console.log(this.infoPlayer.plateauBoat.boats);

    console.log("update grid")

    for (let y = 0; y < 10; y++) {
      for (let x = 0; x < 10; x++) {
        grid[y + 1][x + 1] = this.infoPlayer.plateauBoat.plateau[y * 10 + x];
      }
    }

    this.grid = [...grid];
    this.bateaux = this.infoPlayer.listBoatForStart.listBoat;
  };


  changeOrientation(): void {
    //console.log("changeOrientation")
    this.isVertical = !this.isVertical;
  }

  selectBateau(bateau: any): void {
    this.bateauAposer = bateau;
  }

  poserBateau(x: number, y: number): void {
    //console.log("x : " + x + " y : " + y + " bateau : " + this.bateauAposer);
    if (x !== undefined && y !== undefined && this.bateauAposer !== undefined) {

      this.bateauAposer.x = x;
      this.bateauAposer.y = y;
      this.bateauAposer.orientation = this.isVertical;
      console.log(this.bateauAposer);
      this.navalWarRequestService.PoserBateau(this.infoGame.idGame, this.infoPlayer.idPlayer, this.bateauAposer, this.infoPlayer.player1or2).subscribe(
        (data) => {
          this.navalWarDataStoreService.setNewPlateauBoat(data.plateauBoat);
          this.navalWarDataStoreService.setNewListBoatForStart(data.listBoatForStart);
          this.navalWarDataStoreService.setGlobalErrorMessage({ message: data.message, titre: 'Placement Bateau', type: 'success' } as GlobalMessage);
        },
        (error) => this.navalWarDataStoreService.setGlobalErrorMessage({ message: error.error, titre: 'Placement Bateau', type: 'error' } as GlobalMessage)

      );
      this.bateauAposer = undefined;
    }
  };

  findBoat(x: number, y: number): number {
    let idBoat = -1;
    this.infoPlayer.plateauBoat.boats.forEach((boat: any) => {
      boat.composant.forEach((element: any) => {
        if (element.x === x && element.y === y) {
          idBoat = (boat.id as number);
        }
      });
    });
    return idBoat;
  }

  supprimerBateau(x: number, y: number, type: string): void {
    //console.log("x : " + x + " y : " + y);
    if (x !== undefined && y !== undefined && type === "CaseBateau") {
      let id = this.findBoat(x, y);
      this.navalWarRequestService.DeleteBoat(this.infoGame.idGame, this.infoPlayer.idPlayer, id, this.infoPlayer.player1or2).subscribe(
        (data) => {
          console.log(data);
          this.navalWarDataStoreService.setNewPlateauBoat(data.plateauBoat);
          this.navalWarDataStoreService.setNewListBoatForStart(data.listBoatForStart);
          this.navalWarDataStoreService.setGlobalErrorMessage({ message: data.message, titre: 'Suppression Bateau', type: 'success' } as GlobalMessage);

        },
        (error) => {
          this.navalWarDataStoreService.setGlobalErrorMessage({ message: error.error, titre: 'Suppression Bateau', type: 'error' } as GlobalMessage)
        }
      );

    }

  };

  changeModeDelete(): void {
    this.deleteBoat = !this.deleteBoat;
    this.bateauAposer = undefined;
  }


  validerGrille(): void {
    //console.log("validerGrille");
    this.navalWarRequestService.ValiderPlateau(this.infoGame.idGame, this.infoPlayer.player1or2).subscribe(
      (data) => {
        //console.log(data);
        this.navalWarDataStoreService.changeIsReady(data.ok);
        this.navalWarDataStoreService.setGlobalErrorMessage({ message: data.message, titre: 'Validation', type: 'success' } as GlobalMessage);
      },
      (error) => this.navalWarDataStoreService.setGlobalErrorMessage({ message: error.error, titre: 'Validation', type: 'error' } as GlobalMessage)
    );
  };


  handleRightClick(x: number, y: number, type: string): void {
    if (this.deleteBoat === true) {
      this.supprimerBateau(x, y, type);
    }
    else {
      this.poserBateau(x, y);
    }
  }




  ngOnInit(): void {
    this.navalWarDataStoreService.onInfoPlayerChange().subscribe(
      (suggestion) => {
        this.infoPlayer = suggestion;
        this.BackToFrondGrid();
      }
    );
    this.navalWarDataStoreService.onInfoGameChange().subscribe(
      suggestion => this.infoGame = suggestion);
  }


}
