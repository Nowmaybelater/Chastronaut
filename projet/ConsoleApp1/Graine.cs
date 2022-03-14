using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Graine : RessourcePlantation
    {
        public Graine(int Quantite) : base(Quantite, 1) // 1 = 1 jour i.e. quand on passe à la journée d'après les graines sont récoltées 
        { }

        public override void Utiliser()
        {

        }
    }
}
