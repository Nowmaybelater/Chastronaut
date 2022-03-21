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

        public Extraterrestre() : base("Extraterrestre", 3)
        {
            PositionExtraterrestre = new int[] { 0, 0 };
        }

        public override void AllerActivite()
        {

        }

        public void VolerFaim(Chats chat)
        {
            if(chat.NiveauDeFaim<=2)
            {
                chat.NiveauDeFaim = 0;
            }
            else
            {
                chat.NiveauDeFaim = chat.NiveauDeFaim - 2;
            }
        }

        public void VolerEnergie(Chats chat)
        {
            if (chat.NiveauEnergie <= 2)
            {
                chat.NiveauEnergie = 0;
            }
            else
            {
                chat.NiveauEnergie = chat.NiveauEnergie - 2;
            }
        }

        public void VolerDivertissement(Chats chat)
        {
            if (chat.NiveauDivertissement <= 2)
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
