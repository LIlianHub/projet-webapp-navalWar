using NavalWar.DTO;
using NavalWar.DTO.Bateau;
using NavalWar.DTO.Plateau;
using System.Xml.Linq;

namespace NavalWar.DTO.User
{
    public class Player
    {
        public string Name { get; set; }

        public PlateauBoat PlateauBoat { get; set; }
        public PlateauShot PlateauShot { get; set; }
        public ListBoatForStart ListBoatForStart { get; set; }

        public bool? IsWinner { get; set; }



        public Player(string name)
        {
            Name = name;
            PlateauBoat = new PlateauBoat(10);
            PlateauShot = new PlateauShot(10);
            ListBoatForStart = new ListBoatForStart("Classique");
            IsWinner = false;
        }

        public Player(string name, PlateauBoat plateauBoat, PlateauShot plateauShot, ListBoatForStart listBoatForStart, bool? isWinner)
        {
            Name = name;
            PlateauBoat = plateauBoat;
            PlateauShot = plateauShot;
            ListBoatForStart = listBoatForStart;
            IsWinner = isWinner;
        }
    }
}