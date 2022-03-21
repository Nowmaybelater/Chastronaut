using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Carriere:Batiments
    {
        public Carriere() : base(0, 0)
        {
            PositionBatiment = new int[] { Ligne+2, Colonne + 3 };
            NumeroBatiment = 3;
        }

        public override void Construire(Carte map)
        {
            for (int i = Ligne; i < Ligne + 5; i++)
            {
                for (int j = Colonne; j < Colonne+7; j++)
                {
                    map.Map[i, j] = " / ";
                }
            }
            map.Map[Ligne+2, Colonne+2] = " Ca";
            map.Map[Ligne+2, Colonne + 3] = "rri";
            map.Map[Ligne+2, Colonne + 4] = "ere";
        }
    }
}
