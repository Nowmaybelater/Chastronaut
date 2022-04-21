using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Metier : Fonction
    {

        //Constructeur
        protected Metier(string nom, int num) : base(nom, num)
        {
        }

        //La méthode AllerActivite gère la téléportation d'un chat vers le lieu correspondant à l'activité qu'il doit réaliser
        public void AllerActivite(Chats chat, Batiments lieu)
        {
            chat.PositionChat = lieu.PositionBatiment; 
        }

        public abstract void AgirAutomatiquement(Chats chat, List<Ressources> listeRessources, int numeroAction);//méthode abstraite que l'on redéfinit dans ses classes filles
    }
}
