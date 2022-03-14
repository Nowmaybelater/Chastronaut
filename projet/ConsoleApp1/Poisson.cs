using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Poisson : RessourceAlimentaire
    {
        public Poisson(int Quantite) : base(Quantite, 5) { }
        public override void Utiliser()
        {

        }
    }
}
