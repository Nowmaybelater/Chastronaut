using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Graines : RessourcePlantation
    {
        //Constructeur qui attribue le numéro 8 à la ressource Graines
        public Graines(int Quantite) : base(Quantite)  
        {
            Numero = 8;
            Nom = "Graine";
        }
    }
}
