using NavalWar.DTO.Jeu;
using NavalWar.DTO.Plateau;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NavalWar.DAL.Models
{
    public class PlayerDb
    {
        
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }

        public string? plateauBoat { get; set; }
        public string? plateauShot { get; set; }

        public string? listeBoatForStart { get; set; }

        public bool? IsWinner { get; set; }


    }
}
