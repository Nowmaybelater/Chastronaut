using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Guerisseur : PnJ
    {
        //Constructeur
        public Guerisseur() : base("Guérisseur", 7)
        { }

        //Ici, la méthode AllerActivite permet aux Chastronautes de se rendre à l'infirmerie, où se trouve le PnJ Guérisseur
        public override void AllerActivite(Chats chat, int[] lieu)
        {
            chat.PositionChat = lieu;
        }

        //La méthode suivante permet au Guérisseur de soigner le chat qui est venu lui rendre visite, c'est-à-dire qu'il remet son niveau d'énergie au maximum
        public void Soigner(Chats chat)
        {
                chat.NiveauEnergie = 10;
                chat.NiveauDeFaim += 3;
            //on n'enlève pas de points au niveaux de santé de ce chat, car il vient de se faire soigner 
        }
    }
}
