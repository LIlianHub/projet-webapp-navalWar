using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.Plateau;
using NavalWar.DTO.Bateau;

namespace NavalWar.Business.ObjectRequest
{
    public class EditBoatAnswer
    {
        public string Message { get; set; }
        public PlateauBoat? PlateauBoat { get; set; }

        public ListBoatForStart? ListBoatForStart { get; set; }

        public bool? IsPlaced { get; set; }

        public EditBoatAnswer(string message, PlateauBoat? plateauBoat, bool? isPlaced, ListBoatForStart? listBoatForStart)
        {
            Message = message;
            PlateauBoat = plateauBoat;
            IsPlaced = isPlaced;
            ListBoatForStart = listBoatForStart;
        }
    }
}
