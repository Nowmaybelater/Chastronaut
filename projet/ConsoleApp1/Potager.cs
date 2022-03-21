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

        public override void Construire(Carte map)
        {
            for (int i = Ligne; i < Ligne + 6; i++)
            {
                for (int j = Colonne; j < Colonne + 7; j++)
                {
                    map.carte[i, j] = " u ";
                }
            }
            map.carte[Ligne + 2, Colonne + 2] = " Po";
            map.carte[Ligne + 2, Colonne + 3] = "tag";
            map.carte[Ligne + 2, Colonne + 4] = "er ";
        }
    }
}
