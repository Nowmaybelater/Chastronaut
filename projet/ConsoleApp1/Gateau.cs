using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Gâteau : RessourceAlimentaire
    {
        public Gâteau(int Quantite) : base(Quantite, 9) { } //on met 9 mais en fait ça remet la barre au max

        public override void Utiliser()
        {

        }

    }
}
