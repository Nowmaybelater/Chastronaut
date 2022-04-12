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

        public Extraterrestre() : base("Extraterrestre", 6)
        {
            PositionExtraterrestre = new int[] { 0, 0 };
        }

        public override void AllerActivite(Chats chat, int[] lieu)
        {
            PositionExtraterrestre[0] = chat.PositionChat[0]-1;
            PositionExtraterrestre[1] = chat.PositionChat[1]-1;
        }

        public void VolerFaim(Chats chat)
        {
            if(chat.NiveauDeFaim<=1)
            {
                chat.NiveauDeFaim = 0;
            }
            else
            {
                chat.NiveauDeFaim = chat.NiveauDeFaim - 1;
            }
        }

        public void VolerEnergie(Chats chat)
        {
            if (chat.NiveauEnergie <= 1)
            {
                chat.NiveauEnergie = 0;
            }
            else
            {
                chat.NiveauEnergie = chat.NiveauEnergie - 1;
            }
        }

        public void VolerDivertissement(Chats chat)
        {
            if (chat.NiveauDivertissement <= 1)
            {
                chat.NiveauDivertissement = 0;
            }
            else
            {
                chat.NiveauDivertissement = chat.NiveauDivertissement - 1;
            }
        }
    }
}
