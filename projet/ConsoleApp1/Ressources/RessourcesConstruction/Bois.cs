using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Bois:RessourceConstruction
    {
        //Constructeur qui attribue le numéro 4 à la ressource Bois
        public Bois(int Quantite) : base(Quantite)
        {
            Numero = 4;
            Nom = "Bois";
        }

    }
}
