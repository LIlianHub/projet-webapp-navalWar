using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.Bateau;
using NavalWar.DTO.ObjectElementPlateau;

namespace NavalWar.DTO.Plateau
{
    public class PlateauShot : IPlateau
    {
        public List<ElementPlateau> plateau { get; set; }


        public PlateauShot(int taille)
        {
            plateau = new List<ElementPlateau>();
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    plateau.Add(new CaseEau(j, i));
                }
            }
        }

        // deserialization
        public PlateauShot()
        {

        }

        public void AffichePlateau()
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (plateau[i * 10 + j] is not CaseEau)
                    {
                        if ((plateau[i * 10 + j]).Type == "ShotOnMapMissed")
                        {
                            Console.Write("O");
                        }
                        else
                        {
                            Console.Write("X");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            string retour = "Plateau Shot:\nLe Plateau:\n";
            foreach (ElementPlateau elementPlateau in plateau)
            {
                retour += elementPlateau.ToString() + "\n";
            }
            return retour;
        }

        public void SetElementPlateau(ElementPlateau elementPlateau)
        {
            plateau[elementPlateau.X + elementPlateau.Y * 10] = elementPlateau;
        }

        public ElementPlateau GetElementPlateau(int x, int y)
        {
            return plateau[x + y * 10];
        }
    }

}
