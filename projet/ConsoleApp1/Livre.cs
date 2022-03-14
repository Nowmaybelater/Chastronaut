using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Livre : RessourceCulturelle
    {
        
        public Livre(int Quantite) : base(Quantite, 3) 
        { 

        } //on fixe le taux de divertissement à 3

        public override void Utiliser()
        { }

        public override string ToString ()
        {
            string chRes = "Nb Livres : " + this.Quantite;
            return chRes;
        }

    }
}
