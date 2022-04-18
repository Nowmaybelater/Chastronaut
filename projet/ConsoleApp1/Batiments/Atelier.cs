using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Atelier:Batiments
    {
        //Constructeur 
        public Atelier() : base(4, 25)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 1;
        }

        //La méthode Construire permet ici de construire un Atelier dans la carte, dont la présence est nécessaire pour que l'Artiste puisse fabriquer les divertissements
        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            map.Map[Ligne, Colonne] = " At";
            map.Map[Ligne, Colonne+1] = "eli";
            map.Map[Ligne, Colonne+2] = "er ";
            listeBatiments.Add(this);
        }
    }
}
