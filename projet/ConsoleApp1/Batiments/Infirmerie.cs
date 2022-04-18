using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Infirmerie:Batiments
    {
        //Constructeur
        public Infirmerie() : base(12, 18)
        {
            PositionBatiment = new int[] { Ligne, Colonne + 1 };
            NumeroBatiment = 7;
        }

        //La méthode Construire permet ici de construire une Infirmerie dans la carte, dont la présence est nécessaire pour que les Chats puissent rendre visite au PnJ Guérisseur et se faire soigner
        public override void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            Bois bois = listeRessources[3] as Bois;
            Pierres pierre = listeRessources[4] as Pierres;
            if (pierre.Quantite >= 1 && bois.Quantite >= 1) //l'infirmerie n'étant pas présente sur la carte au début de la partie, il est possible pour le joueur de la construire. La boucle if permet de s'assurer qu'il dispose des ressources nécessaires
            {
                map.Map[Ligne, Colonne] = "Inf";
                map.Map[Ligne, Colonne + 1] = "irm";
                map.Map[Ligne, Colonne + 2] = "eri";
                map.Map[Ligne, Colonne + 3] = "e  ";
                pierre.Quantite -= 1;
                bois.Quantite -= 1;
                listeBatiments.Add(this);
            }
            else //Si le joueur ne dispose pas des ressources nécessaires pour construire l'infirmerie, un message d'erreur s'affiche
            {
                if (bois.Quantite < 1)
                {
                    Console.WriteLine("Attention ! Vous ne pocédez pas assez de bois pour construire une infirmerie");
                }
                else
                {
                    Console.WriteLine("Attention ! Vous ne pocédez pas assez de pierres pour construire une infirmerie");
                }
            }

        }
    }
}
