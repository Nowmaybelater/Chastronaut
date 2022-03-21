using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Pierres : RessourceConstruction
    {
        public Pierres(int Quantite) : base(Quantite)
        {
            Numero = 6;
        }

        public override void Utiliser()
        {

        }
    }
}
