using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cantine:Batiments
    {
        //Constructeur
        public Cantine():base(16, 25)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 2;
        }

        //La méthode Construire permet ici de construire une Cantine dans la carte, dont la présence est nécessaire pour que les Chastronautes puissent manger
        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            map.Map[Ligne, Colonne] = " Ca";
            map.Map[Ligne, Colonne+1] = "nti";
            map.Map[Ligne, Colonne+2] = "ne ";
            listeBatiments.Add(this);
        }
    }
}
