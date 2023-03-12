using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.Business.ObjectRequest
{
    public class ShotRequest
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int IdPlayer { get; set; }
        public int IdSession { get; set; }

        public int IdEnnemy { get; set; }

        public ShotRequest(int x, int y, int idPlayer, int idSession, int idEnnemy)
        {
            X = x;
            Y = y;
            IdPlayer = idPlayer;
            IdSession = idSession;
            IdEnnemy = idEnnemy;
        }
    }
}
