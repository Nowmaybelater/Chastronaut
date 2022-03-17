using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Carte
    {
        public string[,] carte
        {
            get;
            set;
        }

        public Carte()
        {
            carte = new string[20, 50];
            for (int i = 0; i < 20; i++)//initialisation d'une grille vierge
            {
                for (int j = 0; j < 50; j++)
                {
                    carte[i, j] = " . ";
                }
            }
        }

        public override string ToString()
        {
            string affichage = "";
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    affichage += carte[i, j];
                }
                affichage += "\n";
            }
            return affichage;
        }




    }
}
