using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.ObjectElementPlateau;

namespace NavalWar.DTO.Bateau
{
    public interface IBoat
    {
        bool Alive { get; set; }
        List<CaseBateau> composant { get; set; }

        int X { get; set; }
        int Y { get; set; }
        
        int ID { get; }

        string Type{ get; set;}

        string ToString();

    }
}
