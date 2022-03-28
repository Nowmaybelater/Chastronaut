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

        public bool Construire(int numeroBatiment, Carte map, Chats chat, Bois bois, Pierres pierre)
        {
            bool action = true; //la variable est vraie quand le joueur veut effectuer une action réalisable par le chat incarné, elle est fausse quand il choisie une action non réalisable
            if (chat._Fonction is Batisseur)
            {
                if (numeroBatiment == 7)
                {
                    Infirmerie infirmerie = new Infirmerie();
                    infirmerie.Construire(map, bois, pierre);
                    Console.WriteLine(" La construction de ce bâtiment vous a permis de débloquer un Chastronaute Guérisseur. " +
                        "\n Celui - ci peut remettre au maximum les barres de faim, d'énergie et de divertissement du chat " +
                        "\n que vous incarnez. Pour cela, il vous faut vous rendre à l'infirmerie.Attention, vous ne pouvez " +
                        "\n consulter le Guérisseur qu'une seule fois tous les x tours.");
                }
                else
                {
                    if (numeroBatiment == 8)
                    {
                        Poste poste = new Poste();
                        poste.Construire(map, bois, pierre);
                        Console.WriteLine(" La construction de ce bâtiment vous a permis de débloquer un Chastronaute Messager. " +
                            "\n Celui - ci peut vous offrir des ressources supplémentaires, que vous obtiendrez en vous " +
                            "\n rendant au bureau de poste. Attention, vous ne pouvez consulter le Messager que tous les" +
                            "\n x tours.");

                    }
                    else
                    {
                        if (numeroBatiment == 9)
                        {
                            Potager potager = new Potager();
                            potager.Construire(map, bois, pierre);
                            Console.WriteLine("La construction du potager vous a permis de débloquer un deuxième Chastronaute Agriculteur.");

                        }
                        else
                        {
                            if (numeroBatiment == 10)
                            {
                                ZoneDePeche zoneDePeche = new ZoneDePeche();
                                zoneDePeche.Construire(map, bois, pierre);
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
            else
            {
                Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Construire");
                action = false;
            }
            return action;
        }

        public bool AbattreUnArbre(Bois bois,Chats chat)
        {
            bool action = true; //la variable est vraie quand le joueur veut effectuer une action réalisable par le chat incarné, elle est fausse quand il choisie une action non réalisable
            if (chat._Fonction is Batisseur)
            {
                bois.Quantite += 2;
                chat.NiveauDeFaim -= 1;
                chat.NiveauDivertissement -= 1;
                chat.NiveauEnergie -= 1;
            }
            else
            {
                Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action AbattreUnArbre");
                action = false;
            }
            return action;
        }


        public bool Miner(Pierres pierre,Chats chat)
        {
            bool action = true; //la variable est vraie quand le joueur veut effectuer une action réalisable par le chat incarné, elle est fausse quand il choisie une action non réalisable
            if (chat._Fonction is Batisseur)
            {
                pierre.Quantite += 2;
                chat.NiveauDeFaim -= 1;
                chat.NiveauDivertissement -= 1;
                chat.NiveauEnergie -= 1;
            }
            else
            {
                Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Miner");
                action = false;
            }
            return action;
        }

    }
}
