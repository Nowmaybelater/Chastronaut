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

        //Constructeur 
        public Carte()
        {
            Map = new string[20, 50];
            for (int i = 0; i < 20; i++)//initialisation d'une grille vierge
            {
                for (int j = 0; j < 50; j++)
                {
                    Map[i, j] = " . "; //le fond de la carte est représenté par le symbole "."
                }
            }
        }
    }
}
