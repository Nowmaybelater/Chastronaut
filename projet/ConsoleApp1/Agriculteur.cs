﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Agriculteur : Metier
    {
        public Agriculteur() : base("Agriculteur", 2)
        { }

        public override void AllerActivite(Chats chat, Batiments lieu)
        {
            chat.PositionChat = lieu.PositionBatiment;
        }

        public void Recolter()
        {

        }

        public void Planter()
        {

        }
    }
}
