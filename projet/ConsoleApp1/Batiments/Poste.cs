using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Poste:Batiments
    {
        //Constructeur 
        public Poste() : base(8, 18)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 8;
        }

        //La méthode Construire permet ici de construire un Bureau de Poste dans la carte, dont la présence est nécessaire pour que les Chats puissent rendre visite au PnJ Messager et recevoir des ressources
        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            Bois bois = listeRessources[3] as Bois;
            Pierres pierre = listeRessources[4] as Pierres;
            if (pierre.Quantite>=1 && bois.Quantite>=1) //le bureau de poste n'étant pas présent sur la carte au début de la partie, il est possible pour le joueur de le construire. La boucle if permet de s'assurer qu'il dispose des ressources nécessaires
            {
                map.Map[Ligne, Colonne] = "  Po";
                map.Map[Ligne, Colonne + 1] = "s";
                map.Map[Ligne, Colonne + 2] = "te  ";
                pierre.Quantite -= 1;
                bois.Quantite -= 1;
                listeBatiments.Add(this);
            }
            else //Si le joueur ne dispose pas des ressources nécessaires pour construire le bureau de poste, un message d'erreur s'affiche
            {
                if(bois.Quantite<1)
                {
                    Console.WriteLine("Attention ! Vous ne pocédez pas assez de bois pour construire un bureau de poste");
                }
                else
                {
                    Console.WriteLine("Attention ! Vous ne pocédez pas assez de pierres pour construire un bureau de poste");
                }
            }

        }
    }
}
