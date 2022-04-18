using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cuisine:Batiments
    {
        //Constructeur
        public Cuisine() : base(8, 32)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 4;
        }

        //La méthode Construire permet ici de construire une Cuisine dans la carte, dont la présence est nécessaire pour que le Patissier puisse faire des gâteaux
        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            map.Map[Ligne, Colonne] = " Cu";
            map.Map[Ligne, Colonne+1] = "isi";
            map.Map[Ligne, Colonne+2] = "ne ";
            listeBatiments.Add(this);
        }
    }
}
