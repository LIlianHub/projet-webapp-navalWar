using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.Bateau;
using NavalWar.DTO.ObjectElementPlateau;

namespace NavalWar.DTO.Plateau
{
    public class PlateauBoat : IPlateau
    {
        public List<ElementPlateau> plateau { get; set; }
        public List<Boat> Boats { get; set; }

        // Pour la construction du plateau à la main
        // sinon il duplique les case en appelant ce constructeur !
        public PlateauBoat(int taille)
        {
            plateau = new List<ElementPlateau>();
            Boats = new List<Boat>();
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    plateau.Add(new CaseEau(j, i));
                }
            }
        }

        // Pour la deserialisation
        public PlateauBoat()
        {

        }

        public bool AddBoatOnPlateau(Boat boat)
        {
            if (IsValidBoat(boat))
            {
                Boats.Add(boat);
                foreach (CaseBateau caseBateau in boat.composant)
                {
                    plateau[caseBateau.X + caseBateau.Y * 10] = caseBateau;
                }
                return true;
            }
            return false;
        }

        public bool IsValidBoat(Boat boat)
        {
            foreach (CaseBateau caseBateau in boat.composant)
            {
                //Console.WriteLine(caseBateau.X + " " + caseBateau.Y + " " + (plateau[caseBateau.X + caseBateau.Y * 10] is not CaseEau));
                if(caseBateau.X >= 10 || caseBateau.Y >= 10 || caseBateau.X < 0 || caseBateau.Y < 0 || plateau[caseBateau.X + caseBateau.Y * 10] is not CaseEau)
                { 
                    return false;
                }
            }
            //Console.WriteLine("up");
            return true;
        }

        private void RemoveBoatOnPlateau(Boat boat)
        {
            foreach (CaseBateau caseBateau in boat.composant)
            {
                plateau[caseBateau.X + caseBateau.Y * 10] = new CaseEau(caseBateau.X, caseBateau.Y);
                Console.WriteLine("Indice dans liste suppression: " + caseBateau.X  + caseBateau.Y * 10);
            }
        }

        public void AffichePlateau()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (plateau[i * 10 + j] is CaseBateau)
                    {
                        Console.Write("X");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool RemoveBoat(int id)
        {
            int index = Boats.FindIndex(a => a.ID == id);
            bool retour = false;
            if (index != -1)
            {
                RemoveBoatOnPlateau(Boats[index]);
                Boats.RemoveAt(index);
                retour = true;
            }
            return retour;
        }

        public override string ToString()
        {
            string retour = "Plateau Boat:\nLe Plateau:\n";
            foreach (ElementPlateau elementPlateau in plateau)
            {
                retour += elementPlateau.ToString() + "\n";
            }
            retour += "Les Bateaux:\n";
            foreach (Boat bateau in Boats)
            {
                retour += bateau.ToString() + "\n";
            }
            return retour;
        }

        public Boat? GetBoat(int id)
        {
            return Boats.Find(a => a.ID == id);
        }

        public ElementPlateau GetElementPlateau(int x, int y)
        {
            return plateau[x + y * 10];
        }

        public void SetElementPlateau(ElementPlateau elementPlateau)
        {
            plateau[elementPlateau.X + elementPlateau.Y * 10] = elementPlateau;
        }

        // return true si le bateau est touché en entier et false sinon
        public bool HitBoat(int idBoat, int x, int y)
        {
            int index = Boats.FindIndex(a => a.ID == idBoat);
            if (index != -1)
            {
                Boats[index].GetTouched(x, y);
                return CheckBoat(idBoat);
            }
            return false;
        }

        // return true si le bateau est touché en entier et false sinon
        public bool CheckBoat(int idBoat)
        {
            int index = Boats.FindIndex(a => a.ID == idBoat);
            if (index != -1)
            {
                // bateau touché en entier
                if (Boats[index].composant.Count == 0)
                {
                    Boats[index].Alive = false;
                    return true;
                }
            }
            return false;
        }

        public void RepairBoatsAfterSerialization()
        {
            foreach(Boat boat in Boats)
            {
                boat.RepairBoatAfterSerialization();
                foreach(CaseBateau casebateau in boat.composant)
                {
                    plateau[casebateau.X + casebateau.Y * 10] = casebateau;
                }
            }
        }

        public bool CheckLoose()
        {
            foreach(Boat boat in Boats)
            {
                if (boat.Alive)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
