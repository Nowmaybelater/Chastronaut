using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Films : RessourceCulturelle
    {
        //Constructeur qui attribue le numéro 6 à la ressource Films et fixe son taux de divertissement à 5
        public Films(int Quantite) : base(Quantite, 5) 
        {
            Numero = 6;
            Nom = "Film";
        } 
    }
}
