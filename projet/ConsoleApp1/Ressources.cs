using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Ressources
    {
        protected int Quantite { get; set; }

        public Ressources()
        {
            this.Quantite = 5;
        }
        public Ressources(int Quantite)
        {
            this.Quantite = Quantite;
        }

        public abstract void Utiliser();
    }
}
