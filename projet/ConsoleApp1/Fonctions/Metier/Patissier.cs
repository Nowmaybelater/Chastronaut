using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Patissier : Metier
    {
        public Patissier() : base("Pâtissier", 5)
        { }

        public override void AllerActivite(Chats chat, Batiments lieu)
        {
            chat.PositionChat = lieu.PositionBatiment;
        }

        public void Patisser(Chats chat, Gateaux gateau)
        {
            gateau.Quantite += 1;
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }
    }
}
