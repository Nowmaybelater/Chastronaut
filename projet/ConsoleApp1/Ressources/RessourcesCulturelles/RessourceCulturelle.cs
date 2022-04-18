using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class RessourceCulturelle : Ressources
    {
        public int TauxDivertissement { get; set; }

        //Constructeur 
        public RessourceCulturelle(int Quantite, int TauxDivertissement) : base(Quantite)
        {
            this.TauxDivertissement = TauxDivertissement;
        }
    }
}
