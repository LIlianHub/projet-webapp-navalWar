using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.User;


namespace NavalWar.DTO.Jeu
{
    public class Jeu
    {
        public Player player1 { get; set; }
        public Player player2 { get; set; }

        public int AuTourDe { get; set; }

        public int Etat { get; set; }

        public Jeu(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            Etat = -1;
            AuTourDe = 1;
        }

        public Jeu(Player p1, Player p2, int etat, int auTourDe )
        {
            player1 = p1;
            player2 = p2;
            Etat = etat;
            AuTourDe = auTourDe;
        }
    }
}
