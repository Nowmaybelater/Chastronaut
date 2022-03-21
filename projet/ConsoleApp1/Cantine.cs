using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cantine:Batiments
    {
        public Cantine():base(16, 25)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 2;
        }

        public override void Construire(Carte map)
        {
            map.Map[Ligne, Colonne] = " Ca";//Création d'une cantine pour que les chats puissent manger
            map.Map[Ligne, Colonne+1] = "nti";
            map.Map[Ligne, Colonne+2] = "ne ";
        }
    }
}
