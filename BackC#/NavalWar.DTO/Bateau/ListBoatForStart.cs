using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DTO.Bateau
{
    public class ListBoatForStart
    {
        public List<BoatForStart> ListBoat { get; set; }

        public ListBoatForStart(string ModeDeJeu)
        {
            ListBoat = new List<BoatForStart>();
            ListBoat.Add(new BoatForStart(5, 1, "Porte-avion"));
            ListBoat.Add(new BoatForStart(4, 2, "Cuirassé"));
            ListBoat.Add(new BoatForStart(3, 3, "Croiseur"));
            ListBoat.Add(new BoatForStart(3, 4, "Croiseur"));
            ListBoat.Add(new BoatForStart(3, 5, "Croiseur"));
            ListBoat.Add(new BoatForStart(2, 6, "Torpilleur"));
            ListBoat.Add(new BoatForStart(2, 7, "Torpilleur"));
        }

        // deserialization
        public ListBoatForStart() { }

        public void RemoveBoat(int id)
        {
            ListBoat.Remove(ListBoat.Find(x => x.Id == id));
        }
        
        public void AddBoat(BoatForStart boat)
        {
            ListBoat.Add(boat);
        }
    }
}
