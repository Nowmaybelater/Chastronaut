using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Graines : RessourcePlantation
    {
        public Graines(int Quantite) : base(Quantite)  
        {
            Numero = 8;
            Nom = "Graines";
        }
    }
}
