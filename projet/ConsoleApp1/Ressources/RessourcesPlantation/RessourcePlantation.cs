using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class RessourcePlantation : Ressources
    {
        //Constructeur 
        public RessourcePlantation(int Quantite) : base(Quantite)
        {
        }
    }
}
