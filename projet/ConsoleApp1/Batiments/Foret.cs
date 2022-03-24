using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Foret:Batiments
    {
        public Foret() : base(14, 42)
        {
            PositionBatiment = new int[] { Ligne+3, Colonne + 3 };
            NumeroBatiment = 6;
        }

        public override void Construire(Carte map, Bois bois, Pierres pierre)
        {
            for (int i = Ligne+3; i < Ligne+6; i++)
            {
                for (int j = Colonne-2; j < 50; j++)
                {
                    map.Map[i, j] = " x ";
                }
            }
            for (int i = Ligne; i < Ligne+3; i++)
            {
                for (int j = Colonne; j < 50; j++)
                {
                    map.Map[i, j] = " x ";
                }
            }
            map.Map[Ligne + 3, Colonne + 2] = "  F";
            map.Map[Ligne + 3, Colonne + 3] = "ore";
            map.Map[Ligne + 3, Colonne + 4] = "t  ";
        }

    }
}
