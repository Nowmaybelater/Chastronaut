using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Pecheur : Metier
    {
        //Constructeur 
        public Pecheur() : base("Pêcheur", 5)
        { }

        //La méthode suivante gère la pêche de poissons par le chat pêcheur
        public void Pecher(Poissons poisson, Chats chat)
        {
            poisson.Quantite += 5;
            //on enlève un point à chacun des niveaux car le chat vient de réaliser une action
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }

        //La méthode suivante gère le comportement automatique du chat pêcheur, qui réalise les cinq actions suivantes : manger, se reposer, se divertir et pêcher(deux fois)
        public override void AgirAutomatiquement(Chats chat, List<Ressources> listeRessources) //correspond à cinq actions, car un tour est caractérisé par cinq actions pour chaque chat
        {
            Pecheur P = chat.Fonction as Pecheur;

            //comportement automatique pour se nourrir
            int numNourriture = 0;
            for(int i=0; i<=2; i++)
            {
                if(listeRessources[i].Quantite>numNourriture)
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

            if (listeRessources[5].Quantite != 0)//s'il n'y a pas de livre, le chat se divertit avec un film
            {
                chat.SeDivertir(listeRessources[5] as Films);
            }

            //comportement automatique pour se reposer
            chat.SeReposer();

            //comportement automatique de peche d'un poisson (propre au chat pecheur) : on le fait deux fois pour avoir cinq actions = un tour
            P.Pecher(listeRessources[2] as Poissons, chat);
            P.Pecher(listeRessources[2] as Poissons, chat);



        }
    }
}

