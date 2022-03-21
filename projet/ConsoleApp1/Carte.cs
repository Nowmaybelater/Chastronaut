using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Carte
    {
        public string[,] Map
        {
            get;
            set;
        }

        public Carte()
        {
            Map = new string[20, 50];
            for (int i = 0; i < 20; i++)//initialisation d'une grille vierge
            {
                for (int j = 0; j < 50; j++)
                {
                    Map[i, j] = " . ";
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
                    affichage += Map[i, j];
                }
                affichage += "\n";
            }
            return affichage;
        }




    }
}
