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
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 4;
        }

        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            map.Map[Ligne, Colonne] = " Cu";//Création d'une cantine pour que les chats puissent manger
            map.Map[Ligne, Colonne+1] = "isi";
            map.Map[Ligne, Colonne+2] = "ne ";
            listeBatiments.Add(this);
        }
    }
}
