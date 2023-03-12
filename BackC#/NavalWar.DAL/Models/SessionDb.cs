using NavalWar.DTO.Plateau;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.User;
using NavalWar.DTO.Jeu;
using System.ComponentModel.DataAnnotations.Schema;

namespace NavalWar.DAL.Models
{
    public class SessionDb
    {

        [Key]
        public int ID { get; set; }

        public int AuTourDe { get; set; }

        public int Etat { get; set; }

        [ForeignKey("PlayerDb1")]
        public int Player1Id { get; set; }
        public PlayerDb Player1 { get; set; }

        [ForeignKey("PlayerDb2")]
        public int Player2Id { get; set; }
        public PlayerDb Player2 { get; set; }

        public bool Player1Ready { get; set; }
        public bool Player2Ready { get; set; }


    }
}
