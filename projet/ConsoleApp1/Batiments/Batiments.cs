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

        //Constructeur
        public Batiments(int ligne, int colonne)
        {
            Ligne = ligne;
            Colonne = colonne;
        }

        //La méthode Construire est abstraite ici. Elle sera redéfinie dans les classes dérivées afin de permettre l'affichage dans Batiments sur la carte
        public abstract void Construire(Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments);
        
    }
}
