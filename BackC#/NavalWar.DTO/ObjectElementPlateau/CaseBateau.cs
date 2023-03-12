using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using NavalWar.DTO.Bateau;

namespace NavalWar.DTO.ObjectElementPlateau
{
    public class CaseBateau : ElementPlateau
    {
        [JsonIgnore]
        public Boat? Pere;


        public CaseBateau(int x, int y, Boat pere) : base(x, y, "CaseBateau")
        {
            this.Pere = pere;
        }

        public CaseBateau() { }


        public override string ToString()
        {
            return base.ToString();
        }

        public void RepairPere(Boat pere)
        {
            Pere = pere;
        }
       

    }
}
