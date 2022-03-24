using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Batiments
    {
        public int Ligne
        {
            get;
            set;
        }
        public int Colonne
        {
            get;
            set;
        }

        public int[] PositionBatiment
        {
            get;
            set;
        }

        public int NumeroBatiment
        {
            get;
            set;
        }

        public Batiments(int ligne, int colonne)
        {
            Ligne = ligne;
            Colonne = colonne;
        }

        public abstract void Construire(Carte map, Bois bois, Pierres pierre);
    }
}
