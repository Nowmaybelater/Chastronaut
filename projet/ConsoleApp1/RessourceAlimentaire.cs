using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class RessourceAlimentaire : Ressources
    {
        protected int ValeurNutritionnelle { get; set; }


        public RessourceAlimentaire(int Quantite, int ValeurNutritionnelle)
        {
            this.Quantite = Quantite;
            this.ValeurNutritionnelle = ValeurNutritionnelle;
        }
    }
}
