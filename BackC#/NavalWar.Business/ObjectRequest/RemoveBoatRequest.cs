using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.Business.ObjectRequest
{
    public class RemoveBoatRequest
    {
        public int IdPlayer { get; set; }
        public int IdBoat { get; set; }
        public int IdSession { get; set; }

        public int Player1or2 { get; set; }

        public RemoveBoatRequest(int idPlayer, int idBoat, int idSession, int player1or2)
        {
            IdPlayer = idPlayer;
            IdBoat = idBoat;
            IdSession = idSession;
            Player1or2 = player1or2;
        }
    }
}
