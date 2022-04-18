using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Dortoir:Batiments
    {
        //Constructeur
        public Dortoir() : base(12, 32)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 5;
        }

        //La méthode Construire permet ici de construire un Dortoir dans la carte, dont la présence est nécessaire pour que les Chats puissent se reposer
        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            map.Map[Ligne, Colonne] = " Do";
            map.Map[Ligne, Colonne+1] = "rto";
            map.Map[Ligne, Colonne+2] = "ir ";
            listeBatiments.Add(this);
        }
    }
}
