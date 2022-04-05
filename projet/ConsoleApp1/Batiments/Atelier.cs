using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Atelier:Batiments
    {
        public Atelier() : base(4, 25)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 1;
        }

        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            map.Map[Ligne, Colonne] = " At";//Création d'une cantine pour que les chats puissent manger
            map.Map[Ligne, Colonne+1] = "eli";
            map.Map[Ligne, Colonne+2] = "er ";
            listeBatiments.Add(this);
        }
    }
}
