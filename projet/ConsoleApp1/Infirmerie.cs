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
        }

        public override void Construire(Carte map)
        {
            map.carte[Ligne, Colonne] = "Inf";//Création d'une cantine pour que les chats puissent manger
            map.carte[Ligne, Colonne + 1] = "irm";
            map.carte[Ligne, Colonne + 2] = "eri";
            map.carte[Ligne, Colonne + 2] = "e  ";
        }
    }
}
