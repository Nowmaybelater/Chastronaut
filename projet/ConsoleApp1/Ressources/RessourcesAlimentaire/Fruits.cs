using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Fruits : RessourceAlimentaire
    {
        //Constructeur qui attribue le numéro 1 à la ressource Fruits et fixe sa valeur nutritionnelle à 2
        public Fruits(int Quantite) : base(Quantite, 2) 
        {
            Numero = 1;
            Nom = "Fruit";
        }

    }
}
