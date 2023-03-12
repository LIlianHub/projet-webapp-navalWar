using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace NavalWar.DTO.ObjectElementPlateau
{
    public class ElementPlateau : IElementPlateau
    {
        public ElementPlateau(int x, int y, string type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public ElementPlateau() { }
        
        public int X { get; set ; }
        public int Y { get ; set ; }
        public string Type { get; set; }

        public override string ToString()
        {
            return "(" + X + "," + Y + ") " + Type;
        }
    }
}
