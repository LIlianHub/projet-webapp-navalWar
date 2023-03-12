import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { InfoPlayer } from '../models/infoPlayer.model';
import { InfoGame } from '../models/infoGame.model';
import { GlobalMessage } from '../models/globalMessage.model';
/*import { ParoleModele } from '../models/parole.model';
import { ApiMenu } from '../models/recepApi.model';*/


@Injectable({
    providedIn: 'root',
})
export class NavalWarDataStoreService {

    private infoPlayers: BehaviorSubject<InfoPlayer> = new BehaviorSubject({} as InfoPlayer);
    private infoGames: BehaviorSubject<InfoGame> = new BehaviorSubject({} as InfoGame);
    private globalMessagePopUp : BehaviorSubject<GlobalMessage>= new BehaviorSubject({} as GlobalMessage);

    onInfoPlayerChange(): Observable<InfoPlayer> {
        return this.infoPlayers.asObservable();
    }

    onInfoGameChange(): Observable<InfoGame> {
        return this.infoGames.asObservable();
    }

    onGlobalErrorMessageChange(): Observable<GlobalMessage> {
        return this.globalMessagePopUp.asObservable();
    }

    setGlobalErrorMessage(newGlobalErrorMessage: GlobalMessage): void {
        this.globalMessagePopUp.next(newGlobalErrorMessage);
    }

    setInfoPlayer(newInfoPlayer: InfoPlayer): void {
        this.infoPlayers.next(newInfoPlayer);
    }

    setInfoGame(newInfoGame: InfoGame): void {
        this.infoGames.next(newInfoGame);
    }

    requestAnswerToInfoPlayer(data: any, player1or2: number): InfoPlayer {
        let retour: InfoPlayer = {

            idPlayer: data.idPlayer,
            listBoatForStart: data.player.listBoatForStart,
            player1or2: player1or2,
            plateauBoat: data.player.plateauBoat,
            plateauShot: data.player.plateauShot,
            name: data.player.name,
            isReady: data.isReady,
            isWinner: data.player.isWinner,
        }
        return retour;
    }

    requestAnswerToInfoGame(data: any): InfoGame {
        let retour: InfoGame = {
            idGame: data.idGame,
            idEnnemy: data.idEnnemy,
            etatGame: data.etatGame,
            auTourDe: data.auTourDe,
        }
        return retour;
    }

    changeEtatGame(etatGame: number): void {
        let infoGame: InfoGame = this.infoGames.getValue();
        if (etatGame !== infoGame.etatGame) {
            infoGame.etatGame = etatGame;
            this.setInfoGame(infoGame);
        }
    }

    setNewPlateauBoat(plateauBoat: any): void {
        let infoPlayer: InfoPlayer = this.infoPlayers.getValue();
        infoPlayer.plateauBoat = plateauBoat;
        this.setInfoPlayer(infoPlayer);
    }

    setNewPlateauShot(plateauShot: any): void {
        let infoPlayer: InfoPlayer = this.infoPlayers.getValue();
        infoPlayer.plateauShot = plateauShot;
        this.setInfoPlayer(infoPlayer);
    }

    setNewListBoatForStart(listBoatForStart: any): void {
        let infoPlayer: InfoPlayer = this.infoPlayers.getValue();
        infoPlayer.listBoatForStart = listBoatForStart;
        this.setInfoPlayer(infoPlayer);
    }

    changeAuTourDe(auTourDe: number): void {
        let infoGame: InfoGame = this.infoGames.getValue();
        if (auTourDe !== infoGame.auTourDe) {
            infoGame.auTourDe = auTourDe;
            this.setInfoGame(infoGame);
        }
    }

    changeIsReady(isReady: boolean): void {
        let infoPlayer: InfoPlayer = this.infoPlayers.getValue();
        infoPlayer.isReady = isReady;
        this.setInfoPlayer(infoPlayer);
    }

    changeIsWinner(isWinner: boolean): void {
        let infoPlayer: InfoPlayer = this.infoPlayers.getValue();
        infoPlayer.isWinner = isWinner;
        this.setInfoPlayer(infoPlayer);
    }


}