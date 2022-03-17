﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Potager:Batiments
    {
        public Potager() : base(11, 1)
        {
        }

        public Potager(int ligne, int colonne) : base(ligne, colonne)
        {
        }

        public override void Construire(Carte map)
        {
            for (int i = Ligne; i < Ligne + 6; i++)
            {
                for (int j = Colonne; j < Colonne + 7; j++)
                {
                    map.carte[i, j] = " u ";
                }
            }
        }
    }
}
