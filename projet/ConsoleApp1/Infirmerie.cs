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

        public override void Construire(Carte map)
        {
            map.Map[Ligne, Colonne] = "Inf";//Création d'une cantine pour que les chats puissent manger
            map.Map[Ligne, Colonne + 1] = "irm";
            map.Map[Ligne, Colonne + 2] = "eri";
            map.Map[Ligne, Colonne + 2] = "e  ";
        }
    }
}
