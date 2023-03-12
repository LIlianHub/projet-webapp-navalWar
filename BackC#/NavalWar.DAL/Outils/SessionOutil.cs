using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NavalWar.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.User;
using NavalWar.DTO.Jeu;

namespace NavalWar.DAL.Outils
{
    public class SessionOutils
    {
        public static Jeu ToDTO(SessionDb sessiondb, Player p1, Player p2)
        {
            return new Jeu(p1, p2, sessiondb.Etat, sessiondb.AuTourDe);
        }

        public static SessionDb ToDb(Jeu jeu)
        {
            return new SessionDb()
            {
                Player1 = PlayerOutils.ToDb(jeu.player1),
                Player2 = PlayerOutils.ToDb(jeu.player2),
                Etat = jeu.Etat,
                AuTourDe = jeu.AuTourDe,
            };
        }
    }
}
