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
        }

        public override void Construire(Carte map)
        {
            for (int i = Ligne-1; i < Ligne; i++)
            {
                for (int j = Colonne+1; j < 49; j++)
                {
                    map.carte[i, j] = " o ";
                }
            }
            for (int i = Ligne; i < Ligne + 2; i++)
            {
                for (int j = Colonne; j < 50; j++)
                {
                    map.carte[i, j] = " o ";
                }
            }
            for (int i = Ligne+3; i < Ligne+4; i++)
            {
                for (int j = Colonne+1; j < 49; j++)
                {
                    map.carte[i, j] = " o ";
                }
            }
        }
    }
}
