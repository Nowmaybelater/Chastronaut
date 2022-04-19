using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Extraterrestre:PnJ
    {
        public int[] PositionExtraterrestre
        {
            get;
            set;
        }

        //Constructeur 
        public Extraterrestre() : base("Extraterrestre", 6)
        {
            PositionExtraterrestre = new int[] { 0, 0 };
        }

        //Ici, la méthode AllerActivite permet de faire venir un extraterrestre en haut à gauche d'un chat sur la carte 
        public override void AllerActivite(Chats chat, int[] lieu)
        {
            PositionExtraterrestre[0] = chat.PositionChat[0]-1;
            PositionExtraterrestre[1] = chat.PositionChat[1]-1;
        }

        //La méthode suivante permet à l'extraterrestre de voler un point de faim au chat qu'il attaque 
        public void VolerFaim(Chats chat)
        {
            if(chat.NiveauDeFaim<=1)
            {
                chat.NiveauDeFaim = 0;
            }
            else
            {
                chat.NiveauDeFaim = chat.NiveauDeFaim - 2;
            }
        }

        //La méthode suivante permet à l'extraterrestre de voler un point d'énergie au chat qu'il attaque 
        public void VolerEnergie(Chats chat)
        {
            if (chat.NiveauEnergie <= 1)
            {
                chat.NiveauEnergie = 0;
            }
            else
            {
                chat.NiveauEnergie = chat.NiveauEnergie - 2;
            }
        }

        //La méthode suivante permet à l'extraterrestre de voler un point de divertissement au chat qu'il attaque 
        public void VolerDivertissement(Chats chat)
        {
            if (chat.NiveauDivertissement <= 1)
            {
                chat.NiveauDivertissement = 0;
            }
            else
            {
                chat.NiveauDivertissement = chat.NiveauDivertissement - 2;
            }
        }
    }
}
