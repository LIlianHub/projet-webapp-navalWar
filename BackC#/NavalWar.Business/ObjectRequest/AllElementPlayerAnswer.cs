using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.User;

namespace NavalWar.Business.ObjectRequest
{
    public class AllElementPlayerAnswer
    {
        public int IdPlayer { get; set; }
        public Player? Player { get; set; }

        public int IdGame { get; set; }

        public int IdEnnemy { get; set; }
        public string Message { get; set; }

        public int EtatGame { get; set; }

        public int AuTourDe { get; set; }

        public bool? IsReady { get; set; }

        public AllElementPlayerAnswer(int idPlayer, int idEnnemy, int idGame, Player? player, string message, int etatGame, int auTourDe, bool? isReady)
        {
            IdPlayer = idPlayer;
            Player = player;
            Message = message;
            IdGame = idGame;
            IdEnnemy = idEnnemy;
            EtatGame = etatGame;
            AuTourDe = auTourDe;
            IsReady = isReady;
        }


    }
}
