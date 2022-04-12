using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Messager : PnJ
    {

        public Messager() : base("Messager", 8)
        { }

        public override void AllerActivite(Chats chat, Batiments lieu)
        {
            chat.PositionChat = lieu.PositionBatiment;
        }

        public void Livrer(List<Ressources> listeRessources, Chats chat)
        {
            Random rnd = new Random();
            int numero = rnd.Next(1, 8);
            int nombreDeRessources = rnd.Next(1, 10);
            listeRessources[numero - 1].Quantite += nombreDeRessources;
            Console.WriteLine("Vous avez reçu " + nombreDeRessources + " " + listeRessources[numero - 1].Nom + " de la part du chat messager");
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }
    }
}
