import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
/*import { ParoleModele } from '../models/parole.model';
import { ApiMenu } from '../models/recepApi.model';*/


const baseUrl = 'https://localhost:7250/api/';


@Injectable({
  providedIn: 'root',
})

export class NavalWarRequestService {
  constructor(private http: HttpClient) { }

  CreateGame(data: any): Observable<any> {
    return this.http.post<any>(
      baseUrl + 'Game',
      data
    );
  }

  JoinGame(data: any): Observable<any> {
    return this.http.post<any>(
      baseUrl + 'Join',
      data
    );
  }

  RecupDataGame(idGame: number, idPlayer: number): Observable<any> {
    return this.http.post<any>(
      baseUrl + 'Rejoin/' + idGame,
      idPlayer
    );
  }

  GetEtatGame(idGame: number): Observable<any> {
    return this.http.get<any>(
      baseUrl + 'Game/' + idGame
    );
  }

  PoserBateau(idGame: number, idPlayer: number, bateauAPoser: any, player1or2 : any): Observable<any> {
    return this.http.post<any>(
      baseUrl + 'PlateauBoat',
      {
        IdSession: idGame,
        IdPlayer: idPlayer,
        Boat: bateauAPoser,
        Player1or2: player1or2
      }
    );
  }

  ValiderPlateau(infoGame: number, player1or2: number) {
    //console.log(infoGame + " " + player1or2);
    return this.http.put<any>(
      baseUrl + 'Join',
      {
        "idSession": infoGame,
        "player1or2": player1or2,
      }
    );
  }

  Shot(x: number, y: number, idPlayer: number, idSession: number, idEnnemy: number): Observable<any> {
    return this.http.post<any>(
      baseUrl + 'PlateauShot',
      {
        "x": x,
        "y": y,
        "idPlayer": idPlayer,
        "idSession": idSession,
        "idEnnemy": idEnnemy
      }
    );
  }

  GetPlateauBoat(idPlayer: number): Observable<any> {
    return this.http.get<any>(
      baseUrl + 'PlateauBoat/' + idPlayer
    );
  }

  GetAuTourDeQui(idGame: number): Observable<any> {
    return this.http.get<any>(
      baseUrl + 'Rejoin/' + idGame
    );
  }

  DeleteBoat(idGame: number, idPlayer: number, idBoat: number, player1or2 : number): Observable<any> {

    let options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        "idSession": idGame,
        "idPlayer": idPlayer,
        "idBoat": idBoat,
        "player1or2": player1or2
      },
    };

    return this.http.delete<any>(
      baseUrl + 'PlateauBoat',
      options
    );
  }








}
