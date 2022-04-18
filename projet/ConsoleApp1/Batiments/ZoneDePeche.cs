using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ZoneDePeche:Batiments
    {
        //Constructeur
        public ZoneDePeche() : base(2, 44)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 3 };
            NumeroBatiment = 10;
        }

        //La méthode Construire permet ici de construire une Zone de Pêche dans la carte, dont la présence est nécessaire pour que le Pêcheur puisse pêcher des poissons
        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            Pierres pierre = listeRessources[4] as Pierres;
            //la boucle permet d'utiliser des symboles "o" pour délimiter la zone occupée par la Zone de Pêche
            if (pierre.Quantite>=2) //la zone de pêche n'étant pas présente sur la carte au début de la partie, il est possible pour le joueur de la construire. La boucle if permet de s'assurer qu'il dispose des ressources nécessaires
            {
                for (int i = Ligne - 1; i < Ligne; i++)
                {
                    for (int j = Colonne + 1; j < 49; j++)
                    {
                        map.Map[i, j] = " o ";
                    }
                }
                for (int i = Ligne; i < Ligne + 3; i++)
                {
                    for (int j = Colonne; j < 50; j++)
                    {
                        map.Map[i, j] = " o ";
                    }
                }
                for (int i = Ligne + 3; i < Ligne + 4; i++)
                {
                    for (int j = Colonne + 1; j < 49; j++)
                    {
                        map.Map[i, j] = " o ";
                    }
                }
                map.Map[Ligne, Colonne + 2] = " Zo";
                map.Map[Ligne, Colonne + 3] = "ne ";
                map.Map[Ligne, Colonne + 4] = "de ";
                map.Map[Ligne + 1, Colonne + 2] = "  P";
                map.Map[Ligne + 1, Colonne + 3] = "ech";
                map.Map[Ligne + 1, Colonne + 4] = "e  ";
                pierre.Quantite -= 2;
                listeBatiments.Add(this);
            }
            else //Si le joueur ne dispose pas des ressources nécessaires pour construire la zone de pêche, un message d'erreur s'affiche
            {
                Console.WriteLine("Attention ! Vous ne pocédez pas assez de pierres pour construire la zone de pêche");
            }
        }
    }
}
