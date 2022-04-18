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
        public Metier(string nom, int num) : base(nom, num)
        {
        }

        public abstract void AllerActivite(Chats chat, Batiments lieu);//méthode abstraite que l'on redéfinit dans ses classes filles

        public abstract void AgirAutomatiquement(Chats chat, List<Ressources> listeRessources);//méthode abstraite que l'on redéfinit dans ses classes filles
    }
}
