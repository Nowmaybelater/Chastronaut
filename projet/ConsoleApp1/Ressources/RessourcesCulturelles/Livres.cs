using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Livres : RessourceCulturelle
    {
        
        public Livres(int Quantite) : base(Quantite, 3)  //on fixe le taux de divertissement à 3
        {
            Numero = 7;
            Nom = "Livres";
        }

    }
}
