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


        public Carte()
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

        public void VisualiserChats(List<Chats> ListeChats, Chats Chat)
        {
            string affichagePosition = Map[Chat.PositionChat[0], Chat.PositionChat[1]];
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Map[Chat.PositionChat[0], Chat.PositionChat[1]] = affichagePosition;
            Console.BackgroundColor = ConsoleColor.Black;

            for (int k = 0; k < ListeChats.Count; k++)
            {
                if (ListeChats[k].PositionChat[0] != Chat.PositionChat[0] && ListeChats[k].PositionChat[1] != Chat.PositionChat[1])
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Map[ListeChats[k].PositionChat[0], ListeChats[k].PositionChat[1]] = affichagePosition;
                    Console.BackgroundColor = ConsoleColor.Black;
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
                    affichage += Map[i, j];
                }
                affichage += "\n";
            }
            return affichage;
        }




    }
}
