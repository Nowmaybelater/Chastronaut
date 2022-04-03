using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Infirmerie:Batiments
    {
        public Infirmerie() : base(12, 18)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 7;
        }

        public override void Construire(Carte map, List<Ressources> listeRessources)
        {
            Bois bois = listeRessources[3] as Bois;
            Pierres pierre = listeRessources[4] as Pierres;
            if (pierre.Quantite >= 1 && bois.Quantite >= 1)
            {
                map.Map[Ligne, Colonne] = "Inf";//Création d'une cantine pour que les chats puissent manger
                map.Map[Ligne, Colonne + 1] = "irm";
                map.Map[Ligne, Colonne + 2] = "eri";
                map.Map[Ligne, Colonne + 3] = "e  ";
                pierre.Quantite -= 1;
                bois.Quantite -= 1;
            }
            else
            {
                if (bois.Quantite < 1)
                {
                    Console.WriteLine("Attention ! Vous ne pocédez pas assez de bois pour construire un bureau de poste");
                }
                else
                {
                    Console.WriteLine("Attention ! Vous ne pocédez pas assez de pierres pour construire un bureau de poste");
                }
            }

        }
    }
}
