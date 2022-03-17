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
            for (int i = 0; i < 4; i++)//Création d'une carrière pour miner des pierres
            {
                for (int j = 0; j < 7; j++)
                {
                    carte[i, j] = " / ";
                }
            }
            for (int i = 17; i < 20; i++)//Création d'une forêt pour abattre des arbres
            {
                for (int j = 40; j < 50; j++)
                {
                    carte[i, j] = " x ";
                }
            }
            for (int i = 14; i < 17; i++)//Création d'une forêt pour abattre des arbres
            {
                for (int j = 42; j < 50; j++)
                {
                    carte[i, j] = " x ";
                }
            }
            for (int i = 11; i < 17; i++)//Création d'une champ d'agriculture
            {
                for (int j = 1; j < 8; j++)
                {
                    carte[i, j] = " u ";
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
