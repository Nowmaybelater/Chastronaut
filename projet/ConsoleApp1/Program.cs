using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programme principal");
            Livres L1 = new Livres(3);
            Console.WriteLine(L1);
            SubirAttaque(L1);

            Carte carte = InitialiserCarte();
            Console.WriteLine(carte);

            Console.ReadLine();
        }

        public static string PresenterJeu(ref bool veutJouer)
        {
            veutJouer = true; //booléen utile dans le programme principal : selon la valeur de veutJouer, une partie se relance ou pas
            Console.WriteLine(" \n ==================== BIENVENUE SUR LE JEU CATS COLONY ! ==================== \n ");

            Console.Write(" Choisissez le nom de votre colonie : ");
            string nomColonie = Console.ReadLine();

            Console.WriteLine(" \n Voulez-vous afficher l'histoire ? (tapez NON pour passer, appuyez sur la touche entrée sinon)");
            string afficheHistoire = Console.ReadLine();
            if (afficheHistoire != "NON")
            {
                Console.WriteLine(" \n =================================== HISTOIRE =================================== \n ");
                Console.WriteLine(" "); //à compléter
                Console.WriteLine(" \n ==================================================================================== \n ");

                Console.WriteLine(" \n =================================== REGLES DU JEU =================================== \n ");
                Console.WriteLine(" "); //à compléter
                Console.WriteLine(" \n ==================================================================================== \n ");

            }

            Console.WriteLine(" Prêt ? (tapez QUITTER si vous ne souhaitez pas poursuivre, appuyez sur la touche entrée sinon)");
            string sortie = Console.ReadLine();

            if (sortie != "QUITTER")
                Console.WriteLine(" C'est parti ! Bonne chance ! \n");
            else
            {
                Console.WriteLine(" \n A bientôt !");
                veutJouer = false; //la valeur de veutJouer change parce que le joueur ici ne veut pas continuer à jouer après la lecture de l'histoire
            }
            Console.WriteLine(" \n ==================================================================================== \n ");

            return (nomColonie);

        }

        public static void SubirAttaque(Livres L)
        {
            L.EtrePille();
            Console.WriteLine(L);
        }

        public static Carte InitialiserCarte()
        {
            Carte map = new Carte();

            Carriere carriere = new Carriere();//Création d'une carrière pour miner des pierres
            carriere.Construire(map);

            Foret foret = new Foret();//Création d'une forêt pour abattre des arbres
            foret.Construire(map);

            Potager potager = new Potager();//Création d'une champ d'agriculture
            potager.Construire(map);

            Cantine cantine = new Cantine();//Création d'une cantine pour que les chats puissent manger
            cantine.Construire(map);

            Dortoir dortoir = new Dortoir();//Création d'un dortoir pour que les chats puissent se reposer
            dortoir.Construire(map);

            Cuisine cuisine = new Cuisine();//Création d'une cuisine pour que les chats pâtissiers puissent faire des gâteaux
            cuisine.Construire(map);

            Atelier atelier = new Atelier();//Création d'un atelier pour que les chats artistes puissent créer du divertissement
            atelier.Construire(map);

            return map;
        }

    }
}
