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

        public void EtrePille() //les aliens volent un item des ressources
        {
            if (this.Quantite <= 1)
                this.Quantite = 0;
            else
                this.Quantite -= 1;
        }
    }
}
