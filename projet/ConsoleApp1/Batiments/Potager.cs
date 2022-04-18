using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Potager:Batiments
    {
        //Constructeur pour le potager initialement présent sur la carte
        public Potager() : base(11, 1)
        {
            PositionBatiment = new int[] { Ligne+2, Colonne + 3 };
            NumeroBatiment = 9;
        }

        //Constructeur pour le deuxième potager, dont l'emplacement est choisi par la fonction Construire de la classe Batisseur 
        public Potager(int ligne, int colonne) : base(ligne, colonne)
        {
            PositionBatiment = new int[] { Ligne + 2, Colonne + 3 };
            NumeroBatiment = 9;
        }

        //La méthode Construire permet ici de construire les potagers, en fonction du constructeur utilisé. 
        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            Bois bois = listeRessources[3] as Bois;

            //les boucles vont permettre d'utiliser des symboles "u" pour délimiter la zone occupée par les potagers

            if (Ligne==11)//il n'y a pas de problème de ressource pour le premier potager car il est déjà présent en début de partie 
            {
                for (int i = Ligne; i < Ligne + 6; i++)
                {
                    for (int j = Colonne; j < Colonne + 7; j++)
                    {
                        map.Map[i, j] = " u ";
                    }
                }
                map.Map[Ligne + 2, Colonne + 2] = " Po";
                map.Map[Ligne + 2, Colonne + 3] = "tag";
                map.Map[Ligne + 2, Colonne + 4] = "er ";
                listeBatiments.Add(this);
            }
            else //Cette boucle est relative à la construction du deuxième potager 
            {
                if(bois.Quantite>=2) //le deuxième potager n'étant pas présent sur la carte au début de la partie, il est possible pour le joueur de le construire. La boucle if permet de s'assurer qu'il dispose des ressources nécessaires
                {
                    for (int i = Ligne; i < Ligne + 6; i++)
                    {
                        for (int j = Colonne; j < Colonne + 7; j++)
                        {
                            map.Map[i, j] = " u ";
                        }
                    }
                    map.Map[Ligne + 2, Colonne + 2] = " Po";
                    map.Map[Ligne + 2, Colonne + 3] = "tag";
                    map.Map[Ligne + 2, Colonne + 4] = "er ";
                    bois.Quantite -= 2;
                }
                else //Si le joueur ne dispose pas des ressources nécessaires pour construire le second potager, un message d'erreur s'affiche
                {
                    Console.WriteLine("Attention ! Vous ne pocédez pas assez de bois pour construire un deuxième potager");

                }
            }
        }
    }
}
