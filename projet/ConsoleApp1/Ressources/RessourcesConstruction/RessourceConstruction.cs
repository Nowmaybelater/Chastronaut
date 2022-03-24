using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class RessourceConstruction : Ressources
    {
        public RessourceConstruction(int Quantite) : base(Quantite)
        { }

        //est-ce qu'il faut rajouter la méthode abstract ??
    }
}
