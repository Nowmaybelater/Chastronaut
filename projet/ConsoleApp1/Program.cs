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

            //pour tester l'initialisation du jeu
            bool veutJouer = true;
            string nomColonie = PresenterJeu(ref veutJouer);

            Carte carte = InitialiserCarte();
            Console.WriteLine(carte);

            Console.ReadLine();
        }

        public static string PresenterJeu(ref bool veutJouer)
        {
            veutJouer = true; //booléen utile dans le programme principal : selon la valeur de veutJouer, une partie se relance ou pas
            Console.WriteLine(" \n ==================== BIENVENUE SUR LE JEU CHASTRONAUTES ! ==================== \n ");
            Console.Write(" Pour une meilleure expérience de jeu, pensez à afficher la console en plein écran ! \n");

            Console.WriteLine(" \n Voulez-vous afficher l'histoire ? (tapez NON pour passer, appuyez sur la touche entrée sinon)");
            string afficheHistoire = Console.ReadLine();
            if (afficheHistoire != "NON")
            {
                Console.WriteLine(" \n ================================== HISTOIRE ================================== \n ");
                Console.WriteLine(" Dans une galaxie éloignée de la notre, un peuple de chats vivait dans la paix et la " +
                    "\n prospérité. Alors que leur nombre grandissait, les plus courageux d'entre eux décidèrent de " +
                    "\n partir explorer l'espace à la recherche d'une nouvelle planète : on les baptisa les Chastronautes." +
                    "\n Au cours d'un long voyage à bord de leur vaisseau et de nombreuses péripéties, l'appareil qui " +
                    "\n permettait aux Chastronautes de rester en contact avec leur colonie fut endommagé. Contraints" +
                    "\n d'interrrompre leur voyage pour réparer l'appareil, les Chastronautes atterrirent sur une planète" +
                    "\n d'apparence accueillante. Un peuple d'extraterrestres habitait déjà la planète, mais après plusieurs " +
                    "\n négociations, ils acceptèrent de partager leur territoire le temps pour les Chastronautes de reprendre" +
                    "\n contact avec les leurs..."); 

                Console.WriteLine(" \n ================================ REGLES DU JEU ================================ \n ");
                Console.WriteLine(" Au cours de la partie, vous allez devoir aider les Chastronautes à survivre le temps" +
                    "\n que leur appareil de communication soit réparé. A chaque tour, vous incarnez " +
                    "\n l'un des Chastronautes. Chacun des Chastronautes que vous incarnez possède un " +
                    "\n rôle particulier : bâtisseur, pêcheur, agriculteur, artiste ou pâtissier. " +
                    "\n Pendant un tour, vous devez effectuer 5 actions avec le Chastronaute que " +
                    "\n vous incarnez, actions qui dépendent du rôle du personnage. Une fois les " +
                    "\n 5 actions réalisées, un nouveau tour commence, au cours duquel vous incarnez " +
                    "\n un nouveau Chastronaute. Selon vos stratégies de jeu, vous incarnerez entre" +
                    "\n 5 et 9 des Chastronautes. Il existe également un messager et un guérisseur " +
                    "\n que vous pouvez débloquer mais que vous ne pourrez pas enrôler. en construisant" +
                    "\n la postePour remporter la partie, vous devez vous assurer de maintenir" +
                    "\n les niveaux de faim, de divertissement et de repos de chacun des personnages que vous " +
                    "\n incarnerez. Attention cependant aux extraterrestres qui, voyant que les Chastronautes" +
                    "\n tardent à repartir, lancent des attaques pour tenter de les chasser de la planète !"); 
                Console.WriteLine(" \n ==================================================================================== \n ");

            }

            Console.Write(" \n Choisissez le nom de votre colonie : ");
            string nomColonie = Console.ReadLine();

            Console.WriteLine(" Prêt à aider les Chastronautes dans leur mission ? (tapez QUITTER si vous ne souhaitez pas poursuivre, appuyez sur la touche entrée sinon)");
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

        public static void SubirAttaque(Chats chat)
        {
            Extraterrestre ET = new Extraterrestre();
            ET.VolerFaim(chat);
            ET.VolerEnergie(chat);
            ET.VolerDivertissement(chat);

            Console.WriteLine ("Vous avez été attaqué ! Votre Chastronaute a perdu 1 point de Faim, 1 point d'Energie et 1 point de Divertissement ")
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
