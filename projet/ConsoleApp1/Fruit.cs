using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Fruit : RessourceAlimentaire
    {

        public Fruit(int Quantite) : base(Quantite, 2) { }

        public override void Utiliser()
        {

        }
    }
}
