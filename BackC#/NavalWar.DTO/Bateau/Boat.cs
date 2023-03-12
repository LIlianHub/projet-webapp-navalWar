
using NavalWar.DTO.ObjectElementPlateau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DTO.Bateau
{
    public class Boat : IBoat
    {
        public bool Alive { get; set; }
        public List<CaseBateau> composant { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        
        public int Length { get; set; }
        public int ID { get; }

        public string Type { get; set; }
        public Boat(int x, int y, bool orientation, int length, int id, string type)
        {
            X = x;
            Y = y;
            Alive = true;
            Length = length;
            Type = type;
            composant = new List<CaseBateau>();
            ID = id;
            if (orientation)
            {
                for (int i = 0; i < length; i++)
                {
                    composant.Add(new CaseBateau(x, y + i, this));
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    composant.Add(new CaseBateau(x + i, y, this));
                }
            }

        }

        public override string ToString()
        {
            return "(" + X + "," + Y + ") " + Type + " " + ID + " " + Length + " " + Alive;
        }

        public void GetTouched(int x, int y)
        {
            int index = composant.FindIndex(a => a.X == x && a.Y == y);
            if(index != -1)
            {
                composant.RemoveAt(index);
            }
        }

        public void RepairBoatAfterSerialization()
        {
            foreach (CaseBateau caseBateau in composant)
            {
                caseBateau.RepairPere(this);
            }
        }


    }
}

