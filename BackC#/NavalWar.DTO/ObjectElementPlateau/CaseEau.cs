using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DTO.ObjectElementPlateau
{
    public class CaseEau : ElementPlateau
    {
        public CaseEau(int x, int y): base(x, y, "CaseEau")
        {
            
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
