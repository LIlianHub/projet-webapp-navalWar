using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.ObjectElementPlateau;


namespace NavalWar.DTO.Plateau
{
    public interface IPlateau
    {
        List<ElementPlateau> plateau { get; set; }
        void AffichePlateau();
        string ToString();
        ElementPlateau GetElementPlateau(int x, int y); 
    }
}
