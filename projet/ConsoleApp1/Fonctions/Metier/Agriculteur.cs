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

        public void Recolter(Chats chat, Fruits fruits, Graines graines)
        {
            fruits.Quantite += 1;
            graines.Quantite += 3;
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }

        public void Planter(Chats chat, Graines graines)
        {
            graines.Quantite -= 1;
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }

        public void AgirAutomatiquement (Chats chat, List<Ressources> listeRessources)
        {
            Agriculteur A = chat._Fonction as Agriculteur;
            RessourceAlimentaire R = listeRessources[0] as RessourceAlimentaire;

            //comportement automatique pour se nourrir
            if (listeRessources[0].Quantite != 0) //le chat va commencer par manger le fruit de façon automatique car c'est le moins nourissant
            {
                if (R!=null)
                {
                    chat.Manger(listeRessources[0]);
                }
            }
            else if (listeRessources[2].Quantite != 0) //s'il n'y a pas de fruits, le chat mange un gateau
            {
                chat.Manger(listeRessources[2]);
            }
            else if (listeRessources[3].Quantite != 0) //s'il n'y a ni fruits ni gateaux, le chat mange un poisson
            {
                chat.Manger(listeRessources[2]);
            }

            //comportement automatique pour se divertir
            if (listeRessources[6].Quantite != 0) //le chat commencer automatiquement par se divertir avec un livre
            {
                chat.SeDivertir(listeRessources[6]);
            }

            if (listeRessources[5].Quantite != 0)//s'il n'y a pas de livre, le chat se divertit avec un film
            {
                chat.SeDivertir(listeRessources[5]);
            }

            //comportement automatique pour se reposer
            chat.SeReposer();

            //comportement automatique de récolte (propre au chat agriculteur)
            A.Recolter(chat, listeRessources[0], listeRessources[7]);

            //comportement automatique de plantation (propre au chat agriculteur)
            A.Planter(chat, );
        }
    }
}
