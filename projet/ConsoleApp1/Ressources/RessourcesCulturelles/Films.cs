using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Films : RessourceCulturelle
    {
        public Films(int Quantite) : base(Quantite, 5) //on fixe le taux de divertissement à 5
        {
            Numero = 6;
            Nom = "Films";
        } 

        public override void Utiliser()
        { }
    }
}
