using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Guerisseur : PnJ
    {
        public Guerisseur() : base("Guérisseur", 7)
        { }

        public override void AllerActivite(Chats chat, Batiments lieu)
        {
            chat.PositionChat = lieu.PositionBatiment;
        }

        public void Soigner(Chats chat)
        {
            chat.NiveauEnergie = 10;
        }
    }
}
