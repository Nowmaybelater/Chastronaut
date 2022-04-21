using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class PnJ : Fonction
    {
        //Constructeur passé en protected car il n'est utile que dans les classes filles de la classe PnJ et pas dans l'entiereté du code
        protected PnJ(string nom, int num) : base(nom, num)
        {
        }

        //La méthode abstraite suivante sera redéfinie dans les classes dérivées de PnJ
        public abstract void AllerActivite(Chats chat, int[] lieu);

    }
}
