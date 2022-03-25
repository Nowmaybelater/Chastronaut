using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Agriculteur : Metier
    {
        public Agriculteur() : base("Agriculteur", 2)
        { }

        public override void AllerActivite(Chats chat, Batiments lieu)
        {
            chat.PositionChat = lieu.PositionBatiment;
        }

        public bool Recolter(Chats chat, Fruits fruits, Graines graines)
        {
            bool action = true; //la variable est vraie quand le joueur veut effectuer une action réalisable par le chat incarné, elle est fausse quand il choisie une action non réalisable
            if(chat._Fonction is Agriculteur)
            {
                fruits.Quantite += 1;
                graines.Quantite += 3;
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

        public bool Planter(Chats chat, Graines graines)
        {
            bool action = true; //la variable est vraie quand le joueur veut effectuer une action réalisable par le chat incarné, elle est fausse quand il choisie une action non réalisable
            if (chat._Fonction is Agriculteur)
            {
                graines.Quantite -= 1;
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
