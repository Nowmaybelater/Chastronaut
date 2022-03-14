using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Fonction
    {
        public string Nom
        {
            get;
            set;
        }

        public int Numéro
        {
            get;
            set;
        }
        public Fonction(string nom, int num)
        {
            Nom = nom;
            Numéro = num;
        }
    }
}
