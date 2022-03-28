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

            Bois bois = new Bois(4);
            Pierres pierre = new Pierres(4);

            Carte carte = InitialiserCarte(bois, pierre);
            Console.WriteLine(carte);
            Batisseur batisseur = new Batisseur();
            Chats reglisse = new Chats("Réglisse", batisseur, 10, 10, 10);
            Console.WriteLine(reglisse);
            batisseur.Construire(7, carte, reglisse, bois, pierre);
            Console.WriteLine(reglisse);
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
                    "\n prospérité. Alors que leur nombre grandissait, les plus courageux d'entre eux " +
                    "\n décidèrent de partir explorer l'espace à la recherche d'une nouvelle planète : " +
                    "\n on les baptisa les Chastronautes. Au cours d'un long voyage à bord de leur vaisseau " +
                    "\n et de nombreuses péripéties, l'appareil qui permettait aux Chastronautes de rester " +
                    "\n en contact avec leur colonie fut endommagé. Contraints d'interrrompre leur voyage " +
                    "\n pour réparer l'appareil, les Chastronautes atterrirent sur une planète d'apparence " +
                    "\n accueillante. Un peuple d'extraterrestres habitait déjà la planète, mais après " +
                    "\n plusieurs négociations, ils acceptèrent de partager leur territoire le temps " +
                    "\n pour les Chastronautes de reprendre contact avec les leurs...");

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

            Console.WriteLine("\n Prêt à aider les Chastronautes dans leur mission ? (tapez QUITTER si vous ne souhaitez pas poursuivre, appuyez sur la touche entrée sinon)");
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

            Console.WriteLine("Vous avez été attaqué ! Votre Chastronaute a perdu 1 point de Faim, 1 point d'Energie et 1 point de Divertissement ");
        }

        public static Carte InitialiserCarte(Bois bois, Pierres pierre)
        {
            Carte map = new Carte();

            Carriere carriere = new Carriere();//Création d'une carrière pour miner des pierres
            carriere.Construire(map, bois, pierre);

            Foret foret = new Foret();//Création d'une forêt pour abattre des arbres
            foret.Construire(map, bois, pierre);

            Potager potager = new Potager();//Création d'une champ d'agriculture
            potager.Construire(map, bois, pierre);

            Cantine cantine = new Cantine();//Création d'une cantine pour que les chats puissent manger
            cantine.Construire(map, bois, pierre);

            Dortoir dortoir = new Dortoir();//Création d'un dortoir pour que les chats puissent se reposer
            dortoir.Construire(map, bois, pierre);

            Cuisine cuisine = new Cuisine();//Création d'une cuisine pour que les chats pâtissiers puissent faire des gâteaux
            cuisine.Construire(map, bois, pierre);

            Atelier atelier = new Atelier();//Création d'un atelier pour que les chats artistes puissent créer du divertissement
            atelier.Construire(map, bois, pierre);


            return map;
        }

        public static void AfficherResources(List<Ressources> ListeRessources)//affiche toutes les ressources
            //ListeRessoucres rassemble toutes les ressources, la place de la ressource dans la liste correspond à son attribut numéro
        {
            foreach(Ressources r in ListeRessources)
            {
                Console.WriteLine(r);
            }
        }

        public static void FaireAction(int numeroAction)
        {

        }
    }
}
