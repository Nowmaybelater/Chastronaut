using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Poissons : RessourceAlimentaire
    {
        public Poissons(int Quantite) : base(Quantite, 5) 
        {
            Numero = 3;
        }
        public override void Utiliser()
        {

        }
    }
}
