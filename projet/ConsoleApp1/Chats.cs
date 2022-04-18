using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Chats
    {
        public string Nom
        {
            get;
            set;
        }

        public Fonction Fonction
        {
            get;
            set;
        }

        public int NiveauDeFaim
        {
            get;
            set;
        }
        public int NiveauEnergie
        {
            get;
            set;
        }
        public int NiveauDivertissement
        {
            get;
            set;
        }
        
        public int[] PositionChat
        {
            get;
            set;
        }

        public Chats(string nom, Fonction fonction, int niveaufaim, int niveauenergie, int niveaudivertissement)
        {
            Nom = nom;
            Fonction = fonction;
            NiveauDeFaim = niveaufaim;
            NiveauEnergie = niveauenergie;
            NiveauDivertissement = niveaudivertissement;
            PositionChat = new int[] { 10, 26 };
        }

        public bool Manger(RessourceAlimentaire aliment)
        {
            bool actionRealisee = true;
            NiveauDeFaim += aliment.ValeurNutritionnelle;
            if (NiveauDeFaim >= 10)
            {
                NiveauDeFaim = 10;
            }
            NiveauDivertissement -= 1;
            NiveauEnergie -= 1;
            aliment.Quantite -= 1;
            return actionRealisee;
        }

        public bool SeReposer()
        {
            bool actionRealisee = true;
            NiveauEnergie = 10;
            NiveauDivertissement -= 1;
            NiveauDeFaim -= 1;
            return actionRealisee;
        }
        public bool SeDivertir(RessourceCulturelle divertissement)
        {
            bool actionRealisee = true;
            NiveauDivertissement += divertissement.TauxDivertissement;
            if (NiveauDivertissement >= 10)
            {
                NiveauDivertissement = 10;
            }
            NiveauDeFaim -= 1;
            NiveauEnergie -= 1;
            divertissement.Quantite -= 1;
            return actionRealisee;
        }

        public void AfficherNiveaux()
        {
            Console.WriteLine("\nNiveau de faim actuel : " + NiveauDeFaim + "\nNiveau d'énergie actuel : " + NiveauEnergie + "\nNiveau de divertissement actuel : " + NiveauDivertissement + "\n");
        }


        public override string ToString()
        {
            return (Nom + " est un chat " + Fonction.Nom + "\n");
        }


    }
}
