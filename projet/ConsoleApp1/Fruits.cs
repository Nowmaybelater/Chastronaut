using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Fruits : RessourceAlimentaire
    {

        public Fruits(int Quantite) : base(Quantite, 2) { }

        public override void Utiliser()
        {

        }
    }
}
