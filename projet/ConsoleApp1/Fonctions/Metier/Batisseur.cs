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
            if (chat._Fonction is Agriculteur)
            {
                if (numeroBatiment == 7)
                {
                    Infirmerie infirmerie = new Infirmerie();
                    infirmerie.Construire(map, bois, pierre);
                    Console.WriteLine("Félicitation ! Vous venez de construire l'infirmerie\n");
                }
                else
                {
                    if (numeroBatiment == 8)
                    {
                        Poste poste = new Poste();
                        poste.Construire(map, bois, pierre);
                        Console.WriteLine("Félicitation ! Vous venez de construire le bureau de poste\n");

                    }
                    else
                    {
                        if (numeroBatiment == 9)
                        {
                            Potager potager = new Potager();
                            potager.Construire(map, bois, pierre);
                            Console.WriteLine("Félicitation ! Vous venez de construire un deuxième potager\n");

                        }
                        else
                        {
                            if (numeroBatiment == 10)
                            {
                                ZoneDePeche zoneDePeche = new ZoneDePeche();
                                zoneDePeche.Construire(map, bois, pierre);
                                Console.WriteLine("Félicitation ! Vous venez de construire la zone de pêche\n");

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
                Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Récolter");
                action = false;
            }
            return action;
        }

        public bool AbattreUnArbre(Bois bois,Chats chat)
        {
            bool action = true; //la variable est vraie quand le joueur veut effectuer une action réalisable par le chat incarné, elle est fausse quand il choisie une action non réalisable
            if (chat._Fonction is Agriculteur)
            {
                bois.Quantite += 2;
                chat.NiveauDeFaim -= 1;
                chat.NiveauDivertissement -= 1;
                chat.NiveauEnergie -= 1;
            }
            else
            {
                Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Récolter");
                action = false;
            }
            return action;
        }


        public bool Miner(Pierres pierre,Chats chat)
        {
            bool action = true; //la variable est vraie quand le joueur veut effectuer une action réalisable par le chat incarné, elle est fausse quand il choisie une action non réalisable
            if (chat._Fonction is Agriculteur)
            {
                pierre.Quantite += 2;
                chat.NiveauDeFaim -= 1;
                chat.NiveauDivertissement -= 1;
                chat.NiveauEnergie -= 1;
            }
            else
            {
                Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Récolter");
                action = false;
            }
            return action;
        }

    }
}
