using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Poissons : RessourceAlimentaire
    {
        //Constructeur qui attribue le numéro 3 à la ressource Poissons et fixe sa valeur nutritionnelle à 5
        public Poissons(int Quantite) : base(Quantite, 5) 
        {
            Numero = 3;
            Nom = "Poisson";
        }
    }
}
