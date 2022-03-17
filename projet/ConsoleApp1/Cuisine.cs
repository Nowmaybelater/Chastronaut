using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cuisine:Batiments
    {
        public Cuisine() : base(8, 32)
        {
        }

        public override void Construire(Carte map)
        {
            map.carte[Ligne, Colonne] = " Cu";//Création d'une cantine pour que les chats puissent manger
            map.carte[Ligne, Colonne+1] = "isi";
            map.carte[Ligne, Colonne+2] = "ne ";
        }
    }
}
