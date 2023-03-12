using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.Plateau;

namespace NavalWar.Business.ObjectRequest
{
    public class ShotAnswer
    {
        public bool? IsHit { get; set; }
        public PlateauShot? PlateauShot { get; set; }
        public string Reponse { get; set; }

        public bool? IsBoatKill { get; set; }
        public bool? IsWinner { get; set; }

        public ShotAnswer(bool? isHit, bool? isWinner, PlateauShot? plateauShot, string reponse, bool? isBoatKill)
        {
            IsHit = isHit;
            PlateauShot = plateauShot;
            Reponse = reponse;
            IsBoatKill = isBoatKill;
            IsWinner = isWinner;
        }
    }
}
