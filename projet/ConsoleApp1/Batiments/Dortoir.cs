using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Dortoir:Batiments
    {
        public Dortoir() : base(12, 32)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 5;
        }

        public override void Construire(Carte map, Bois bois, Pierres pierre)
        {
            map.Map[Ligne, Colonne] = " Do";//Création d'une cantine pour que les chats puissent manger
            map.Map[Ligne, Colonne+1] = "rto";
            map.Map[Ligne, Colonne+2] = "ir ";
        }
    }
}
