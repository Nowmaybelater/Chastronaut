using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class PnJ : Fonction
    {
        public PnJ(string nom, int num) : base(nom, num)
        {
        }
        public abstract void AllerActivite(Chats chat, int[] lieu);//cette méthode permettra aux Chastronautes (et non aux PnJ)de se rendre au lieu dans lequel se trouvent les PnJ afin de réaliser l'action qui leur est associée

    }
}
