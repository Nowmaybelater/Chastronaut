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
        public override void AgirAutomatiquement(Chats chat, List<Ressources> listeRessources, int numeroAction)//correspond à cinq actions, car un tour est caractérisé par cinq actions pour chaque chat
        {
            Artiste A = chat.Fonction as Artiste;
            //comportement automatique de fabrication d'un livre (propre au chat artiste)
            A.Creer(chat, listeRessources[6] as Livres);
            //comportement automatique de fabrication d'un film (propre au chat artiste)
            A.Creer(chat, listeRessources[5] as Films);
            //comportement automatique pour se nourrir
            int numNourriture = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (listeRessources[i].Quantite > numNourriture)
                {
                    numNourriture = i;
                }
            }
            chat.Manger(listeRessources[numNourriture] as RessourceAlimentaire);//le chat va manger une ressource alimentaire existante de façon automatique, la ressource consommée est celle dont la quantité est la plus élevée dans l'inventaire
            //comportement automatique pour se divertir
            if (listeRessources[6].Quantite != 0) //le chat commence automatiquement par se divertir avec un livre
            {
                chat.SeDivertir(listeRessources[6] as Livres);
            }
            else
            {
                if (listeRessources[5].Quantite != 0)//s'il n'y a pas de livre, le chat se divertit avec un film
                {
                    chat.SeDivertir(listeRessources[5] as Films);
                }
            }
            //comportement automatique pour se reposer
            chat.SeReposer();
        }
    }
}
