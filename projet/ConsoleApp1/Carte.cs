using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Carte
    {
        public string[,] Map
        {
            get;
            set;
        }

        public List<Chats> ListeChats
        {
            get;
            set;
        }

        public Chats chat
        {
            get;
            set;
        }

        public Carte(List<Chats> ListeChats, Chats chat)
        {
            Map = new string[20, 50];
            for (int i = 0; i < 20; i++)//initialisation d'une grille vierge
            {
                for (int j = 0; j < 50; j++)
                {
                    Map[i, j] = " . ";
                }
            }
        }

        public override string ToString()
        {
            string affichage = "";
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if(i== chat.PositionChat[0] && j== chat.PositionChat[1])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        affichage += Map[i, j];
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        for(int k=0; k<ListeChats.Count;k++)
                        {
                            if(i == ListeChats[k].PositionChat[0] && j == ListeChats[k].PositionChat[1])
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                                affichage += Map[i, j];
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                    }
                    affichage += Map[i, j];
                }
                affichage += "\n";
            }
            return affichage;
        }




    }
}
