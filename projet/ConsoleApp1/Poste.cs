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
        }

        public override void Construire(Carte map)
        {
            map.carte[Ligne, Colonne] = "  Po";//Création d'une cantine pour que les chats puissent manger
            map.carte[Ligne, Colonne+1] = "s";
            map.carte[Ligne, Colonne+2] = "te  ";
        }
    }
}
