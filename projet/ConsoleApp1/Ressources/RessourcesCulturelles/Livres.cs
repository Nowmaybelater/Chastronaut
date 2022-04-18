using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Livres : RessourceCulturelle
    {
        //Constructeur qui attribue le numéro 7 à la ressource Livres et fixe son taux de divertissement à 3
        public Livres(int Quantite) : base(Quantite, 3) 
        {
            Numero = 7;
            Nom = "Livre";
        }

    }
}
