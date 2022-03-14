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

        public Fonction _Fonction
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

        public Chats(string nom, Fonction fonction, int niveaufaim, int niveauenergie, int niveaudivertissement)
        {
            Nom = nom;
            _Fonction = fonction;
            NiveauDeFaim = niveaufaim;
            NiveauEnergie = niveauenergie;
            NiveauDivertissement = niveaudivertissement;
        }

        public void Manger(RessourceAlimentaire aliment)
        {
            NiveauDeFaim += aliment.ValeurNutritionnelle;
            if (NiveauDeFaim >= 10)
            {
                NiveauDeFaim = 10;
            }
        }

        public void SeReposer()
        {

        }
        public void SeDivertir()
        {

        }

        public void SeDeplacer()
        {

        }

        public override string ToString()
        {
            return (Nom + " est un chat " + _Fonction.Nom + "\nNiveau de faim actuel : " + NiveauDeFaim + "\nNiveau d'énergie actuel : " + NiveauEnergie);
        }


    }
}
