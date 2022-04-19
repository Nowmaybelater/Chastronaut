using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Patissier : Metier
    {
        //Constructeur 
        public Patissier() : base("Pâtissier", 4)
        { }

        //La méthode suivante gère la préparation de gâteaux par le chat patissier
        public void Patisser(Gateaux gateau, Chats chat)
        {
            gateau.Quantite += 1;
            //on enlève un point à chacun des niveaux car le chat vient de réaliser une action
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }

        //La méthode suivante gère le comportement automatique du chat patissier, qui réalise les cinq actions suivantes : manger, se reposer, se divertir et faire un gâteau (deux fois)
        public override void AgirAutomatiquement(Chats chat, List<Ressources> listeRessources, int numeroAction) //correspond à cinq actions, car un tour est caractérisé par cinq actions pour chaque chat
        {
            Patissier P = chat.Fonction as Patissier;
            //comportement automatique de fabrication d'un gâteau (propre au chat patissier) : on le fait deux fois pour avoir cinq actions = un tour
            if (numeroAction == 1)
            {
                P.Patisser(listeRessources[1] as Gateaux, chat);
            }

            if (numeroAction == 2)
            {
                P.Patisser(listeRessources[1] as Gateaux, chat);
            }

            //comportement automatique pour se nourrir
            if (numeroAction == 3)
            {
                int numNourriture = 0;
                for (int i = 0; i <= 2; i++)
                {
                    if (listeRessources[i].Quantite > numNourriture)
                    {
                        numNourriture = i;
                    }
                }
                chat.Manger(listeRessources[numNourriture] as RessourceAlimentaire);//le chat va manger une ressource alimentaire existante de façon automatique, la ressource consommée est celle dont la quantité est la plus élevée dans l'inventaire
            }
            //comportement automatique pour se divertir
            if (numeroAction == 4)
            {
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
            }
            
            //comportement automatique pour se reposer
            if (numeroAction == 5)
            {
                chat.SeReposer();
            }

        }
    }
}
