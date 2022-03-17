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
        }

        public override void Construire(Carte map)
        {
            map.carte[Ligne, Colonne] = " Do";//Création d'une cantine pour que les chats puissent manger
            map.carte[Ligne, Colonne+1] = "rto";
            map.carte[Ligne, Colonne+2] = "ir ";
        }
    }
}
