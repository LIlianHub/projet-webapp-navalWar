using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.Business.ObjectRequest
{
    public class MoveBoatRequest
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Orientation { get; set; }
        public int IdPlayer { get; set; }
        public int IdBoat { get; set; }
        public int IdSession { get; set; }

        public int Player1or2 { get; set; }

        public MoveBoatRequest(int x, int y, bool orientation, int idPlayer, int idBoat, int idSession, int player1or2)
        {
            X = x;
            Y = y;
            Orientation = orientation;
            IdPlayer = idPlayer;
            IdBoat = idBoat;
            IdSession = idSession;
            Player1or2 = player1or2;
        }
    }
}
