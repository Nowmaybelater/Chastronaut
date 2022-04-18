using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Messager : PnJ
    {
        //Constructeur 
        public Messager() : base("Messager", 8)
        { }

        //Ici, la méthode AllerActivite permet aux Chastronautes de se rendre au bureau de poste, où se trouve le PnJ Messager
        public override void AllerActivite(Chats chat, int[] lieu)
        {
            chat.PositionChat = lieu;
        }

        //La méthode suivante permet au Messager d'offrir des ressources au chat qui est venu lui rendre visite
        public void Livrer(List<Ressources> listeRessources, Chats chat)
        {
            Random rnd = new Random();
            int numero = rnd.Next(1, 8);//choix aléatoire d'une des ressources existantes
            int nombreDeRessources = rnd.Next(1, 10);//choix aléatoire du nombre de ressources que le chat va recevoir
            listeRessources[numero - 1].Quantite += nombreDeRessources;//on ajoute nombreDeRessources à la quantité présente dans l'inventaire de la ressource choisie
            Console.WriteLine("Vous avez reçu " + nombreDeRessources + " " + listeRessources[numero - 1].Nom + " de la part du chat messager");
            //on enlève un point à chacun des niveaux car le chat vient de réaliser une action
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }
    }
}
