using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Gateaux : RessourceAlimentaire
    {
        //Constructeur qui attribue le numéro 2 à la ressource Gateaux et fixe sa valeur nutritionnelle à 9
        public Gateaux(int Quantite) : base(Quantite, 9) //on met 9 mais en fait ça remet la barre au max
        {
            Numero = 2;
            Nom = "Gateau";
        }
    }
}
