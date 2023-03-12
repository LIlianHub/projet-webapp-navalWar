using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.Bateau;

namespace NavalWar.Business.ObjectRequest
{
    public class AddBoatRequest
    {
        
        public int IdPlayer { get; set; }
        public int IdSession { get; set; }

        public int Player1or2 { get; set; }

        public BoatForStart Boat { get; set; }

        public AddBoatRequest(int idPlayer, int idSession, BoatForStart boat, int player1or2)
        {
            IdPlayer = idPlayer;
            IdSession = idSession;
            Boat = boat;
            Player1or2 = player1or2;
        }

    }
}
