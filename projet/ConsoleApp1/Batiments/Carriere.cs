using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Carriere:Batiments
    {
        //Constructeur
        public Carriere() : base(0, 0)
        {
            PositionBatiment = new int[] { Ligne+2, Colonne + 3 };
            NumeroBatiment = 3;
        }

        //La méthode Construire permet ici de construire une Carrière dans la carte, dont la présence est nécessaire pour que le Batisseur puisse miner
        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            //la boucle permet d'utiliser des symboles "/" pour délimiter la zone occupée par la Carrière
            for (int i = Ligne; i < Ligne + 5; i++)
            {
                for (int j = Colonne; j < Colonne+7; j++)
                {
                    map.Map[i, j] = " / ";
                }
            }
            map.Map[Ligne+2, Colonne+2] = " Ca";
            map.Map[Ligne+2, Colonne + 3] = "rri";
            map.Map[Ligne+2, Colonne + 4] = "ere";
            listeBatiments.Add(this);
        }
    }
}
