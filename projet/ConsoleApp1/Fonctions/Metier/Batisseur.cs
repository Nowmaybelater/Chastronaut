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

        public void Construire(int numeroBatiment, Carte map, Chats chat, Bois bois, Pierres pierre)
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

        public void AbattreUnArbre(Bois bois,Chats chat)
        {
            bois.Quantite += 2;
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }


        public void Miner(Pierres pierre,Chats chat)
        {
            pierre.Quantite += 2;
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }

    }
}
