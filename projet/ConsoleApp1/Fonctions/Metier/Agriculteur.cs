using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Agriculteur : Metier
    {
        public Agriculteur() : base("Agriculteur", 1)
        { }

        public override void AllerActivite(Chats chat, Batiments lieu)
        {
            chat.PositionChat = lieu.PositionBatiment;
        }

        public void Recolter(Chats chat, List<Ressources> listeRessources)
        {
            listeRessources[0].Quantite += listeRessources[8].Quantite;
            listeRessources[7].Quantite += listeRessources[8].Quantite;
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
            listeRessources[8].Quantite = 0;

        }

        public int Planter(Chats chat, Graines graines)
        {
            if(graines.Quantite>=5)
            {
                graines.Quantite -= 5;
                chat.NiveauDeFaim -= 1;
                chat.NiveauDivertissement -= 1;
                chat.NiveauEnergie -= 1;
                Console.WriteLine("Vous venez de planter 5 graines. Un chat agriculteur pourra les ramasser lors du prochain tour.");
                return 5;
            }
            else//le chat agriculteur en récolte que ce qui a été planté au tour dernier
            {
                Console.WriteLine("Vous avez pû planter {0} graines, elle pourront être récolter par un chat agriculteur lors du prochain tour. \n", graines.Quantite);
                return graines.Quantite;
            }

        }

        public override void AgirAutomatiquement (Chats chat, List<Ressources> listeRessources)//correspond à cinq actions, car un tour est caractérisé par cinq actions pour chaque chat
        {
            Agriculteur A = chat.Fonction as Agriculteur;

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

            //comportement automatique de récolte (propre au chat agriculteur)
            A.Recolter(chat, listeRessources);

            //comportement automatique de plantation (propre au chat agriculteur)
            A.Planter(chat, listeRessources[7] as Graines);
        }
    }
}
