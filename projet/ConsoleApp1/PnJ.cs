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
        public abstract void AllerAuTravail();//méthode abstraite que l'on redéfinit dans ses classes filles

    }
}
