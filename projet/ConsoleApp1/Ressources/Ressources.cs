﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Ressources
    {
        public int Quantite { get; set; }
        public int Numero { get; set; }
        public string Nom { get; set; }

        //Constructeur qui donne une quantité par défaut à la ressource (il est nécessaire à la mise en place des constructeurs des classes filles)
        public Ressources()
        {
            this.Quantite = 5;
        }

        //Constructeur qui donne une quantité choisie à la ressource
        public Ressources(int Quantite)
        {
            this.Quantite = Quantite;
        }


        public override string ToString()
        {
            return "Quantité de " + Nom + " : " + Quantite+"\n";
        }
    }
}
