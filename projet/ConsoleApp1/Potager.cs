using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Potager:Batiments
    {
        public Potager() : base(11, 1)
        {
            PositionBatiment = new int[] { Ligne+2, Colonne + 3 };
            NumeroBatiment = 9;
        }

        public Potager(int ligne, int colonne) : base(ligne, colonne)
        {
            PositionBatiment = new int[] { Ligne + 2, Colonne + 3 };
            NumeroBatiment = 9;
        }

        public override void Construire(Carte map, Bois bois, Pierres pierre)
        {
            if(Ligne==11)//pas de proclème de ressource pour le potager qui est initialiser au début d'une partie
            {
                for (int i = Ligne; i < Ligne + 6; i++)
                {
                    for (int j = Colonne; j < Colonne + 7; j++)
                    {
                        map.Map[i, j] = " u ";
                    }
                }
                map.Map[Ligne + 2, Colonne + 2] = " Po";
                map.Map[Ligne + 2, Colonne + 3] = "tag";
                map.Map[Ligne + 2, Colonne + 4] = "er ";
            }
            else
            {
                if(bois.Quantite>=2)
                {
                    for (int i = Ligne; i < Ligne + 6; i++)
                    {
                        for (int j = Colonne; j < Colonne + 7; j++)
                        {
                            map.Map[i, j] = " u ";
                        }
                    }
                    map.Map[Ligne + 2, Colonne + 2] = " Po";
                    map.Map[Ligne + 2, Colonne + 3] = "tag";
                    map.Map[Ligne + 2, Colonne + 4] = "er ";
                }
                else
                {
                    Console.WriteLine("Attention ! Vous ne pocédez pas assez de bois pour construire un deuxième potager");

                }
            }
        }
    }
}
