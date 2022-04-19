using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Batisseur : Metier
    {
        //constructeur
        public Batisseur() : base("Bâtisseur", 3)
        { }

        //La méthode suivante permet de gérer la construction d'un bâtiment par le chat batisseur 
        public void Construire(int numeroBatiment, Carte map, Chats chat, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<Chats> listeChats, List<PnJ> listePnj)
        {
            if (numeroBatiment == 7)//pour construire l'infirmerie
            {
                Infirmerie infirmerie = new Infirmerie();
                infirmerie.Construire(map, listeRessources, listeBatiments);
                Guerisseur guerisseur = new Guerisseur();
                Chats chatGuerisseur = new Chats("Chat6", guerisseur, 10, 10, 10);
                listeChats.Add(chatGuerisseur);
                listePnj.Add(guerisseur);
                Console.WriteLine(" La construction de ce bâtiment vous a permis de débloquer un chat guérisseur. " +
                    "\n Celui - ci peut remettre au maximum les barres d'énergie du chat " +
                    "\n que vous incarnez. Pour cela, il vous faut vous rendre à l'infirmerie.Attention, vous ne pouvez " +
                    "\n consulter le Guérisseur qu'une seule fois tous les x tours.");
            }
            else
            {
                if (numeroBatiment == 8)//pour construire le bureau de poste 
                {
                    Poste poste = new Poste();
                    poste.Construire(map, listeRessources, listeBatiments);
                    Messager messager = new Messager();
                    Chats chatMessager = new Chats("Chat7", messager, 10, 10, 10);
                    listeChats.Add(chatMessager);
                    listePnj.Add(messager);
                    Console.WriteLine(" La construction de ce bâtiment vous a permis de débloquer un chat messager. " +
                        "\n Celui - ci peut vous offrir des ressources supplémentaires, que vous obtiendrez en vous " +
                        "\n rendant au bureau de poste. Attention, vous ne pouvez consulter le Messager que tous les" +
                        "\n x tours.");

                }
                else
                {
                    if (numeroBatiment == 9)//pour construire le second potager 
                    {
                        Potager potager = new Potager(5,3);
                        potager.Construire(map, listeRessources, listeBatiments);
                        Agriculteur agriculteur2 = new Agriculteur();
                        Chats chatAgriculteur2 = new Chats("Chat8", agriculteur2, 10, 10, 10);
                        listeChats.Add(chatAgriculteur2);
                        Console.WriteLine("La construction du potager vous a permis de débloquer un deuxième chat agriculteur.");

                    }
                    else
                    {
                        if (numeroBatiment == 10)//pour construire la zone de pêche
                        {
                            ZoneDePeche zoneDePeche = new ZoneDePeche();
                            zoneDePeche.Construire(map, listeRessources, listeBatiments);
                            Pecheur pecheur = new Pecheur();
                            Chats chatPecheur = new Chats("Chat9", pecheur, 10, 10, 10);
                            listeChats.Add(chatPecheur);
                            Console.WriteLine("La construction de la zone de pêche vous a permis de débloquer un Chastronaute Pêcheur." +
                                "\n Celui - ci peut réaliser l'action 'Pêcher', qui ajoute des poissons parmi les ressources " +
                                "\n consommables par les Chastronautes. Lorsqu'un Chastronaute mange un poisson, 5 points sont" +
                                "\n ajoutés à sa barre de faim.");

                        }

                    }
                }
            }
            //on enlève un point à chacun des niveaux car le chat vient de réaliser une action
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }

        //La méthode suivante permet de gérer la récolte de bois par le chat bâtisseur 
        public void AbattreUnArbre(List<Ressources> listeRessources, Chats chat)
        {
            Bois bois = listeRessources[3] as Bois;
            bois.Quantite += 2;//ajout du bois récupéré à l'inventaire 
            //on enlève un point à chacun des niveaux car le chat vient de réaliser une action
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;            
        }

        //La méthode suivante permet de gérer la récolte de pierre par le chat bâtisseur 
        public void Miner(List<Ressources> listeRessources, Chats chat)
        {
            Pierres pierre = listeRessources[4] as Pierres;
            pierre.Quantite += 2;//ajout des pierres récupérées à l'inventaire 
            //on enlève un point à chacun des niveaux car le chat vient de réaliser une action
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }

        //La méthode suivante gère le comportement automatique du chat batisseur, qui réalise les cinq actions suivantes : manger, se reposer, se divertir, abattre un arbre et miner
        public override void AgirAutomatiquement(Chats chat, List<Ressources> listeRessources) //correspond à cinq actions, car un tour est caractérisé par cinq actions pour chaque chat
        {
            Batisseur B = chat.Fonction as Batisseur;

            //comportement automatique de la récolte de bois (propre au chat batisseur)
            B.AbattreUnArbre(listeRessources, chat);

            //comportement automatique de la récolte de pierres (propre au chat batisseur)
            B.Miner(listeRessources, chat);

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
