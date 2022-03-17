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
            for (int i = Ligne; i < Ligne + 3; i++)
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
            map.carte[Ligne, Colonne + 2] = " Zo";
            map.carte[Ligne, Colonne + 3] = "ne ";
            map.carte[Ligne, Colonne + 4] = "de ";
            map.carte[Ligne+1, Colonne + 2] = "  P";
            map.carte[Ligne+1, Colonne + 3] = "ech";
            map.carte[Ligne+1, Colonne + 4] = "e  ";
        }
    }
}
