using NavalWar.DTO.ObjectElementPlateau;
using NavalWar.DTO.Jeu;
using NavalWar.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.Business.ObjectRequest;

namespace NavalWar.Business.Game
{
    public interface IGameService
    {
        AllElementPlayerAnswer CreateGame(string namePlayer1);
        AllElementPlayerAnswer JoinGame(int id, string nameP2);
        int? GetEtatGame(int id);
        int[]? GetIdPlayerInGame(int id);
        int GetPlayerTour(int id);
        AllElementPlayerAnswer GetAllPlayerInfo(int idSession, int Player1or2);
        EditValidateAnswer ValideReady(EditValidateRequest editValidateRequest);
        bool? IsPlayerReady(int idSession, int Player1or2);
    }
}
