using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Artiste : Metier
    {
        //Constructeur 
        public Artiste() : base("Artiste", 2)
        { }

        //La méthode suivante permet de gérer la création de ressources culturelles par le chat artiste 
        public void Creer(Chats chat, RessourceCulturelle divertissement)
        {
            divertissement.Quantite += 4;
            //on enlève un point à chacun des niveaux car le chat vient de réaliser une action
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;

        }

        //La méthode suivante gère le comportement automatique du chat artiste, qui réalise les cinq actions suivantes : manger, se reposer, se divertir et créer un divertissement (deux fois)
        public override void AgirAutomatiquement(Chats chat, List<Ressources> listeRessources)//correspond à cinq actions, car un tour est caractérisé par cinq actions pour chaque chat
        {
            Artiste A = chat.Fonction as Artiste;

            //comportement automatique pour se nourrir
            if (listeRessources[0].Quantite != 0) //le chat va commencer par manger le fruit de façon automatique car c'est le moins nourissant
            {
                chat.Manger(listeRessources[0] as Fruits);
            }
            else if (listeRessources[2].Quantite != 0) //s'il n'y a pas de fruits, le chat mange un gateau
            {
                chat.Manger(listeRessources[2] as Poissons);
            }
            else if (listeRessources[1].Quantite != 0) //s'il n'y a ni fruits ni gateaux, le chat mange un poisson
            {
                chat.Manger(listeRessources[1] as Gateaux);
            }

            //comportement automatique pour se divertir
            if (listeRessources[6].Quantite != 0) //le chat commence automatiquement par se divertir avec un livre
            {
                chat.SeDivertir(listeRessources[6] as Livres);
            }

            if (listeRessources[5].Quantite != 0)//s'il n'y a pas de livre, le chat se divertit avec un film
            {
                chat.SeDivertir(listeRessources[5] as Films);
            }

            //comportement automatique pour se reposer
            chat.SeReposer();

            //comportement automatique de fabrication d'un livre (propre au chat artiste)
            A.Creer(chat, listeRessources[6] as Livres);

            //comportement automatique de fabrication d'un film (propre au chat artiste)
            A.Creer(chat, listeRessources[5] as Films);
        }
    }
}
