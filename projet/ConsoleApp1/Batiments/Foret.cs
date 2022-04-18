using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Foret:Batiments
    {
        //Constructeur 
        public Foret() : base(14, 42)
        {
            PositionBatiment = new int[] { Ligne+3, Colonne + 3 };
            NumeroBatiment = 6;
        }

        //La méthode Construire permet ici de construire une Forêt dans la carte, dont la présence est nécessaire pour que le Batisseur puisse abattre des arbres
        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            //la boucle permet d'utiliser des symboles "x" pour délimiter la zone occupée par la Forêt
            for (int i = Ligne+3; i < Ligne+6; i++)
            {
                for (int j = Colonne-2; j < 50; j++)
                {
                    map.Map[i, j] = " x ";
                }
            }
            for (int i = Ligne; i < Ligne+3; i++)
            {
                for (int j = Colonne; j < 50; j++)
                {
                    map.Map[i, j] = " x ";
                }
            }
            map.Map[Ligne + 3, Colonne + 2] = "  F";
            map.Map[Ligne + 3, Colonne + 3] = "ore";
            map.Map[Ligne + 3, Colonne + 4] = "t  ";
            listeBatiments.Add(this);
        }

    }
}
