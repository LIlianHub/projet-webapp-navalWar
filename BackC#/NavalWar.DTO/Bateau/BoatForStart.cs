using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DTO.Bateau
{
    public class BoatForStart
    {
        public int Length
        {
            get; set;
        }
        public string Type
        {
            get; set;
        }
        public int Id
        {
            get; set;
        }

        public int X
        {
            get; set;
        }


        public int Y
        {
            get; set;
        }
        
        public bool Orientation { get; set; }

        public BoatForStart(int length, string type, int id, int x, int y, bool orientation)
        {
            Length = length;
            Type = type;
            Id = id;
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public BoatForStart(int length, int id, string type)
        {
            Length = length;
            Type = type;
            Id = id;
            X = 0;
            Y = 0;
            Orientation = true;
        }

        public BoatForStart() { }
    }
}
