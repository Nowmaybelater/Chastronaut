using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Agriculteur : Metier
    {
        //Constructeur 
        public Agriculteur() : base("Agriculteur", 1)
        { }

        //La méthode suivante permet de récolter les fruits issus des graines plantées précédemment. 
        public void Recolter(Chats chat, List<Ressources> listeRessources, bool afficher)
        {
            //Lorsqu'un chat fait l'action Recolter, il récupère à la fois des fruits et des graines
            listeRessources[0].Quantite += listeRessources[8].Quantite; //récupération des fruits
            listeRessources[7].Quantite += listeRessources[8].Quantite; //récupération des graines 
            if(afficher==true) //l'affichage se fait uniquement lorsque l'action Recolter est réalisée par le chat enrôlé par le joueur. L'affichage ne se fait aps lorsque Recolter est réalisé automatiquement par un autre chat en arrière-plan
            {
                Console.WriteLine("Le chat agriculteur avait planté {0} graine(s) la dernière fois.", listeRessources[8].Quantite);
                Console.WriteLine("Vous avez donc pu récolter {0} fruits et {0} graines.\nVoici vos ressources alimentaires et vos ressources de plantation.", listeRessources[8].Quantite);
                Console.WriteLine(listeRessources[0] + "" + listeRessources[1] + listeRessources[2] + listeRessources[7] + " ");
            }
            //on enlève un point à chacun des niveaux car le chat vient de réaliser une action
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
            listeRessources[8].Quantite = 0;//il n'y a plus de graines en train de pousser

        }

        //La méthode suivante permet de planter des graines. 
        public int Planter(Chats chat, Graines graines, bool afficher)
        {
            if(graines.Quantite>=10) //Automatiquement, les graines sont plantées cinq par cinq 
            {
                graines.Quantite -= 10;
                chat.NiveauDeFaim -= 1;
                chat.NiveauDivertissement -= 1;
                chat.NiveauEnergie -= 1;
                if (afficher == true)
                {
                    Console.WriteLine("Vous venez de planter 10 graines. Vous pouvez dès à présent ramasser votre récolte ou laisser un chat agriculteur s'en occuper lors du prochain tour.");
                }
                return 10;
            }
            else//s'il y a moins de cinq graines dans l'inventaire, toutes les graines de l'inventaire sont plantées
            {
                if (afficher == true)
                {
                    Console.WriteLine("Vous avez pu planter {0} graines. Attention, vous ne posséder plus de graines dans votre inventaire, \npensez à récolter avant la prochaine plantation de graine.", graines.Quantite);
                }
                return graines.Quantite;
            }

        }

        //La méthode suivante gère le comportement automatique du chat agriculteur, qui réalise les cinq actions suivantes : manger, se reposer, se divertir, planter et récolter
        public override void AgirAutomatiquement (Chats chat, List<Ressources> listeRessources)//correspond à cinq actions, car un tour est caractérisé par cinq actions pour chaque chat
        {
            Agriculteur agriculteur = chat.Fonction as Agriculteur;

            //comportement automatique pour se nourrir
            if (listeRessources[0].Quantite != 0) //le chat va commencer par manger le fruit de façon automatique car c'est le moins nourissant
            {
                    chat.Manger(listeRessources[0] as Fruits);
            }
            else if (listeRessources[2].Quantite != 0) //s'il n'y a pas de fruits, le chat mange un poisson
            {
                chat.Manger(listeRessources[2] as Poissons);
            }
            else if (listeRessources[1].Quantite != 0) //s'il n'y a ni fruits ni gateaux, le chat mange un gâteau
            {
                chat.Manger(listeRessources[1] as Gateaux);
            }

            //comportement automatique pour se divertir
            if (listeRessources[6].Quantite != 0) //le chat commence automatiquement par se divertir avec un livre
            {
                chat.SeDivertir(listeRessources[6] as Livres);
            }
            else if (listeRessources[5].Quantite != 0)//s'il n'y a pas de livre, le chat se divertit avec un film
            {
                chat.SeDivertir(listeRessources[5] as Films);
            }

            //comportement automatique pour se reposer
            chat.SeReposer();

            //comportement automatique de récolte (propre au chat agriculteur)
            agriculteur.Recolter(chat, listeRessources, false);

            //comportement automatique de plantation (propre au chat agriculteur)
            agriculteur.Planter(chat, listeRessources[7] as Graines, false);
        }
    }
}
