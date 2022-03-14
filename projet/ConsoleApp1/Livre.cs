using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Livre : RessourceCulturelle
    {
        public Livre(int Quantite) : base(Quantite, 3) { } //on fixe le taux de divertissement à 3

        public override void Utiliser()
        { }

        public void VoleLivre() //les aliens peuvent voler un seul livre à la fois 
        {
            if (this.Quantite <= 1)
                this.Quantite = 0;
            else
                this.Quantite -= 1;
        }
    }
}
