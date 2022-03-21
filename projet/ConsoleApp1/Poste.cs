using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Poste:Batiments
    {
        public Poste() : base(8, 18)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 8;
        }

        public override void Construire(Carte map)
        {
            map.Map[Ligne, Colonne] = "  Po";//Création d'une cantine pour que les chats puissent manger
            map.Map[Ligne, Colonne+1] = "s";
            map.Map[Ligne, Colonne+2] = "te  ";
        }
    }
}
