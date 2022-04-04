using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Batisseur : Metier
    {
        public Batisseur() : base("Bâtisseur", 3)
        { }

        public override void AllerActivite(Chats chat, Batiments lieu)
        {
            chat.PositionChat = lieu.PositionBatiment;
        }

        public void Construire(int numeroBatiment, Carte map, Chats chat, List<Ressources> listeRessources)
        {
            if (numeroBatiment == 7)
            {
                Infirmerie infirmerie = new Infirmerie();
                infirmerie.Construire(map, listeRessources);
                Console.WriteLine(" La construction de ce bâtiment vous a permis de débloquer un Chastronaute Guérisseur. " +
                    "\n Celui - ci peut remettre au maximum les barres d'énergie du chat " +
                    "\n que vous incarnez. Pour cela, il vous faut vous rendre à l'infirmerie.Attention, vous ne pouvez " +
                    "\n consulter le Guérisseur qu'une seule fois tous les x tours.");
            }
            else
            {
                if (numeroBatiment == 8)
                {
                    Poste poste = new Poste();
                    poste.Construire(map, listeRessources);
                    Console.WriteLine(" La construction de ce bâtiment vous a permis de débloquer un Chastronaute Messager. " +
                        "\n Celui - ci peut vous offrir des ressources supplémentaires, que vous obtiendrez en vous " +
                        "\n rendant au bureau de poste. Attention, vous ne pouvez consulter le Messager que tous les" +
                        "\n x tours.");

                }
                else
                {
                    if (numeroBatiment == 9)
                    {
                        Potager potager = new Potager(5,3);
                        potager.Construire(map, listeRessources);
                        Console.WriteLine("La construction du potager vous a permis de débloquer un deuxième Chastronaute Agriculteur.");

                    }
                    else
                    {
                        if (numeroBatiment == 10)
                        {
                            ZoneDePeche zoneDePeche = new ZoneDePeche();
                            zoneDePeche.Construire(map, listeRessources);
                            Console.WriteLine("La construction de la zone de pêche vous a permis de débloquer un Chastronaute Pêcheur." +
                                "\n Celui - ci peut réaliser l'action 'Pêcher', qui ajoute des poissons parmi les ressources " +
                                "\n consommables par les Chastronautes. Lorsqu'un Chastronaute mange un poisson, 5 points sont" +
                                "\n ajoutés à sa barre de faim.");

                        }

                    }
                }
            }
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }

        public void AbattreUnArbre(Bois bois, Chats chat)
        {
            bois.Quantite += 2;
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }


        public void Miner(Pierres pierre, Chats chat)
        {

            pierre.Quantite += 2;
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;

        }

        public void AgirAutomatiquement(Chats chat, List<Ressources> listeRessources) //correspond à cinq actions, car un tour est caractérisé par cinq actions pour chaque chat
        {
            Batisseur B = chat._Fonction as Batisseur;

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

            //comportement automatique de la récolte de bois (propre au chat batisseur)
            B.AbattreUnArbre(listeRessources[3] as Bois, chat);

            //comportement automatique de la récolte de pierres (propre au chat batisseur)
            B.Miner(listeRessources[4] as Pierres, chat);
        }

    }
}
