using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Pierres : RessourceConstruction
    {
        //Constructeur qui attribue le numéro 5 à la ressource Pierres
        public Pierres(int Quantite) : base(Quantite)
        {
            Numero = 5;
            Nom = "Pierre";
        }

    }
}
