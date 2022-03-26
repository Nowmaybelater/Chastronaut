using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Pecheur : Metier
    {
        public Pecheur() : base("Pêcheur", 1)
        { }

        public override void AllerActivite(Chats chat, Batiments lieu)
        {
            chat.PositionChat = lieu.PositionBatiment;
        }

        public bool Pecher(Chats chat,Poissons poisson)
        {
            bool action = true; //la variable est vraie quand le joueur veut effectuer une action réalisable par le chat incarné, elle est fausse quand il choisie une action non réalisable
            if (chat._Fonction is Pecheur)
            {
                poisson.Quantite += 1;
                chat.NiveauDeFaim -= 1;
                chat.NiveauDivertissement -= 1;
                chat.NiveauEnergie -= 1;
            }
            else
            {
                Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Pecher");
                action = false;
            }
            return action;
        }




    }
}
