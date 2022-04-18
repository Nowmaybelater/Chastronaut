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

        //Constructeur qui initialise le nom, la fonction, le niveau de faim, le niveau d'energie et le niveau de divertissement d'un chat, ainsi que sa position initiale 
        public Chats(string nom, Fonction fonction, int niveaufaim, int niveauenergie, int niveaudivertissement)
        {
            Nom = nom;
            Fonction = fonction;
            NiveauDeFaim = niveaufaim;
            NiveauEnergie = niveauenergie;
            NiveauDivertissement = niveaudivertissement;
            PositionChat = new int[] { 10, 26 }; //la position initiale du chat est toujours au centre de la carte
        }

        //La méthode suivante gère ce qu'il se passe quand un chat se nourrit 
        public bool Manger(RessourceAlimentaire aliment)
        {
            bool actionRealisee = true; 
            if(aliment.Quantite>0)
            {
                NiveauDeFaim += aliment.ValeurNutritionnelle;
                if (NiveauDeFaim >= 10)
                {
                    NiveauDeFaim = 10;
                }
                NiveauDivertissement -= 1;
                NiveauEnergie -= 1;
                aliment.Quantite -= 1;
            }
            return actionRealisee; // le booléen actionRealisee permet, dans le programme principal, de compter le nombre d'actions effectuées, et donc de gérer la durée restante d'un tour
        }

        //La méthode suivante gère ce qu'il se passe quand un chat se repose
        public bool SeReposer()
        {
            bool actionRealisee = true;
            NiveauEnergie = 10;
            NiveauDivertissement -= 1;
            NiveauDeFaim -= 1;
            return actionRealisee;// le booléen actionRealisee permet, dans le programme principal, de compter le nombre d'actions effectuées, et donc de gérer la durée restante d'un tour
        }

        //La méthode suivante gère ce qu'il se passe quand un chat se divertit
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
            return actionRealisee;// le booléen actionRealisee permet, dans le programme principal, de compter le nombre d'actions effectuées, et donc de gérer la durée restante d'un tour
        }

        //La méthode suivante permet d'afficher l'état des niveaux de faim, d'énergie et de divertissement du chat
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
