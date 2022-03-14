using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class RessourcePlantation : Ressources
    {
        protected int TempsPousse { get; set; }

        public RessourcePlantation(int Quantite, int TempsPousse) : base(Quantite)
        {
            this.TempsPousse = TempsPousse;
        }
    }
}
