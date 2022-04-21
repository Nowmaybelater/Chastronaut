using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class PnJ : Fonction
    {
        //Constructeur 
        protected PnJ(string nom, int num) : base(nom, num)
        {
        }

        //La méthode abstraite suivante sera redéfinie dans les classes dérivées de PnJ
        public abstract void AllerActivite(Chats chat, int[] lieu);

    }
}
