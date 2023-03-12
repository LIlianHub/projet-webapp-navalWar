using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DTO.ObjectElementPlateau
{
    public class Shot : ElementPlateau
    {
        
        public Shot(int x, int y, string type) : base(x, y, type)
        {
        }

        public Shot() { }

        public override string ToString()
        {
            return base.ToString();

        }
    }
}
