using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ZoneDePeche:Batiments
    {
        public ZoneDePeche() : base(2, 44)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 3 };
            NumeroBatiment = 10;
        }

        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            Pierres pierre = listeRessources[4] as Pierres;
            if (pierre.Quantite>=2)
            {
                for (int i = Ligne - 1; i < Ligne; i++)
                {
                    for (int j = Colonne + 1; j < 49; j++)
                    {
                        map.Map[i, j] = " o ";
                    }
                }
                for (int i = Ligne; i < Ligne + 3; i++)
                {
                    for (int j = Colonne; j < 50; j++)
                    {
                        map.Map[i, j] = " o ";
                    }
                }
                for (int i = Ligne + 3; i < Ligne + 4; i++)
                {
                    for (int j = Colonne + 1; j < 49; j++)
                    {
                        map.Map[i, j] = " o ";
                    }
                }
                map.Map[Ligne, Colonne + 2] = " Zo";
                map.Map[Ligne, Colonne + 3] = "ne ";
                map.Map[Ligne, Colonne + 4] = "de ";
                map.Map[Ligne + 1, Colonne + 2] = "  P";
                map.Map[Ligne + 1, Colonne + 3] = "ech";
                map.Map[Ligne + 1, Colonne + 4] = "e  ";
                pierre.Quantite -= 2;
                listeBatiments.Add(this);
            }
            else
            {
                Console.WriteLine("Attention ! Vous ne pocédez pas assez de pierres pour construire la zone de pêche");
            }
        }
    }
}
