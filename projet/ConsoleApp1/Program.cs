﻿using System;
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

            //Création liste de ressources
            Bois bois = new Bois(4);
            Pierres pierre = new Pierres(4);
            Fruits fruit = new Fruits(4);
            Gateaux gateau = new Gateaux(4);
            Poissons poisson = new Poissons(4);
            Films film = new Films(4);
            Livres livre = new Livres(4);
            Graines graine = new Graines(4);
            List<Ressources> listeRessources = new List<Ressources> { fruit, gateau, poisson, bois, pierre, film, livre, graine };

            //Création liste des Chats
            Agriculteur agriculteur = new Agriculteur();
            Chats ChatAgriculteur = new Chats("Chat1", agriculteur, 10, 10, 10);
            Artiste artiste = new Artiste();
            Chats ChatArtiste = new Chats("Chat2", artiste, 10, 10, 10);
            Batisseur batisseur = new Batisseur();
            Chats ChatBatisseur = new Chats("Chat3", batisseur, 10, 10, 10);
            Patissier patissier = new Patissier();
            Chats ChatPatissier = new Chats("Chat4", patissier, 10, 10, 10);
            Pecheur pecheur = new Pecheur();
            Chats ChatPecheur = new Chats("Chat5", pecheur, 10, 10, 10);
            Guerisseur guerisseur = new Guerisseur();
            Chats ChatGuerisseur = new Chats("Chat6", guerisseur, 10, 10, 10);
            Messager messager = new Messager();
            Chats ChatMessager = new Chats("Chat7", messager, 10, 10, 10);
            List<Chats> listeChats = new List<Chats> { ChatAgriculteur, ChatArtiste, ChatBatisseur, ChatPatissier, ChatPecheur, ChatGuerisseur, ChatMessager };

            //création des batiments pour test
            Atelier atelier = new Atelier();
            Cantine cantine = new Cantine();
            Carriere carriere = new Carriere();
            Cuisine cuisine = new Cuisine();
            Dortoir dortoir = new Dortoir();
            Foret foret = new Foret();
            Infirmerie infirmerie = new Infirmerie();
            Poste poste = new Poste();
            Potager potager = new Potager();
            ZoneDePeche zonedepeche = new ZoneDePeche();
            List<Batiments> listeBatiments = new List<Batiments> { atelier, cantine, carriere, cuisine, dortoir, foret, infirmerie, poste, potager, zonedepeche };
            List<PnJ> listePnj = new List<PnJ> { guerisseur, messager };
            int compteurAction = 0;


            Carte carte = InitialiserCarte(listeRessources);
            infirmerie.Construire(carte, listeRessources);
            poste.Construire(carte, listeRessources);

            ChatBatisseur.NiveauDivertissement -= 7;
            Console.WriteLine(carte);
            Console.WriteLine("\n");
            Console.WriteLine(ChatBatisseur);
            Console.WriteLine(ChatBatisseur.PositionChat[0]);
            Console.WriteLine(ChatBatisseur.PositionChat[1]);
            compteurAction = FaireActionBasique(4, ChatBatisseur, ChatBatisseur._Fonction, listeRessources, listeBatiments, listeChats, carte, compteurAction);
            Console.WriteLine(ChatBatisseur.PositionChat[0]);
            Console.WriteLine(ChatBatisseur.PositionChat[1]);
            Console.WriteLine(ChatBatisseur);

            Console.WriteLine(compteurAction);

            //tests pour les fonctions AgirAutomatiquement
            /*for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(listeRessources[i]);
            }
            agriculteur.AgirAutomatiquement(ChatAgriculteur, listeRessources);
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(listeRessources[i]);
            }
            artiste.AgirAutomatiquement(ChatArtiste, listeRessources);
            for (int i = 0; i<8; i++)
            {
                Console.WriteLine(listeRessources[i]);
            }
            batisseur.AgirAutomatiquement(ChatBatisseur, listeRessources);
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(listeRessources[i]);
            }
            patissier.AgirAutomatiquement(ChatPatissier, listeRessources);
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(listeRessources[i]);
            }
            pecheur.AgirAutomatiquement(ChatPecheur, listeRessources);
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(listeRessources[i]);
            }*/
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
                Console.WriteLine(" Sur une charmante planète, dans une galaxie éloignée de la notre, " +
                    "\n un peuple de chats vivait dans la paix et la prospérité. Alors que leur nombre" +
                    "\n grandissait, l'espace vint à manquer sur la planète des chats. Les plus courageux " +
                    "\n d'entre eux décidèrent de partir explorer l'espace à la recherche d'une nouvelle planète : " +
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

        public static Carte InitialiserCarte(List<Ressources> listeRessources)
        {
            Carte map = new Carte();
            Bois bois = listeRessources[3] as Bois;
            Pierres pierre = listeRessources[4] as Pierres;
            Carriere carriere = new Carriere();//Création d'une carrière pour miner des pierres
            carriere.Construire(map, listeRessources);

            Foret foret = new Foret();//Création d'une forêt pour abattre des arbres
            foret.Construire(map, listeRessources);

            Potager potager = new Potager();//Création d'une champ d'agriculture
            potager.Construire(map, listeRessources);

            Cantine cantine = new Cantine();//Création d'une cantine pour que les chats puissent manger
            cantine.Construire(map, listeRessources);

            Dortoir dortoir = new Dortoir();//Création d'un dortoir pour que les chats puissent se reposer
            dortoir.Construire(map, listeRessources);

            Cuisine cuisine = new Cuisine();//Création d'une cuisine pour que les chats pâtissiers puissent faire des gâteaux
            cuisine.Construire(map, listeRessources);

            Atelier atelier = new Atelier();//Création d'un atelier pour que les chats artistes puissent créer du divertissement
            atelier.Construire(map, listeRessources);


            return map;
        }

        public static void AfficherRessources(List<Ressources> listeRessources)//affiche toutes les ressources
                                                                               //ListeRessoucres rassemble toutes les ressources, la place de la ressource dans la liste correspond à son attribut numéro
        {
            foreach (Ressources ressource in listeRessources)
            {
                Console.WriteLine(ressource);
            }
        }

        public static void AfficherChats(List<Chats> listeChats)//affiche toutes les ressources
                                                                               //ListeRessoucres rassemble toutes les ressources, la place de la ressource dans la liste correspond à son attribut numéro
        {
            int i = 1;
            foreach (Chats chat in listeChats)
            {
                Console.WriteLine(i+":"+chat);
                i += 1;
            }
        }

        public static int FaireActionMetier(int numeroAction, Chats chat, Fonction fonction, List<Ressources> listeRessources, List<Batiments> listeBatiments, Carte map, int compteurAction)
        //ajouter le fait qu'il puisse se faire attaquer par extraterrestre
        //rajouter test si list pnj vide
        {
            bool actionRealisee = true;
            if (numeroAction == 11 && chat._Fonction is Agriculteur) //Recolter
            {
                Agriculteur agriculteur = fonction as Agriculteur;
                agriculteur.AllerActivite(chat, listeBatiments[8]);
                agriculteur.Recolter(chat, listeRessources[0] as Fruits, listeRessources[7] as Graines);
            }
            else
            {   if (numeroAction == 11)
                {
                    Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Récolter");
                    actionRealisee = false;
                }
                else
                {   if (numeroAction == 12 && chat._Fonction is Agriculteur) //Planter
                    {
                        Agriculteur agriculteur = fonction as Agriculteur;
                        agriculteur.AllerActivite(chat, listeBatiments[8]);
                        agriculteur.Planter(chat, listeRessources[7] as Graines);
                    }
                    else
                    {   if (numeroAction == 12)
                        {
                            Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Planter");
                            actionRealisee = false;
                        }
                        else
                        {
                            if (numeroAction == 2 && chat._Fonction is Artiste) //Creer
                            {
                                Console.WriteLine("Que voulez-vous créer ?  \n1 : Film \n2 : Livre");
                                int numRessourceCulturelle = int.Parse(Console.ReadLine());
                                Artiste artiste = fonction as Artiste;
                                artiste.AllerActivite(chat, listeBatiments[0]);
                                if (numRessourceCulturelle == 1)
                                {
                                    artiste.Creer(chat, listeRessources[5] as RessourceCulturelle);
                                }
                                else
                                {
                                    artiste.Creer(chat, listeRessources[6] as RessourceCulturelle);
                                }

                            }
                            else
                            {   if (numeroAction == 2)
                                {
                                    Console.WriteLine("Attention ! Vous devez jouer en tant que chat artiste pour réaliser l'action Créer");
                                    actionRealisee = false;
                                }
                                else
                                {   if (numeroAction == 31 && chat._Fonction is Batisseur) //Construire
                                    {
                                        Console.WriteLine("Que voulez-vous construire ?  \n1 : Infirmarie \n2 : Poste \n3 : Potager \n4 : Zone de pêche ");
                                        int numConstruction = int.Parse(Console.ReadLine()) + 6;
                                        Batisseur batisseur = fonction as Batisseur;
                                        batisseur.Construire(numConstruction, map, chat, listeRessources);

                                    }
                                    else
                                    {   if (numeroAction == 31)
                                        {
                                            Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Construire");
                                            actionRealisee = false;
                                        }
                                        else
                                        {   if (numeroAction == 32 && chat._Fonction is Batisseur) //Abattre un arbre
                                            {
                                                Batisseur batisseur = fonction as Batisseur;
                                                batisseur.AllerActivite(chat, listeBatiments[5]);
                                                batisseur.AbattreUnArbre(listeRessources, chat);
                                            }
                                            else
                                            {   if (numeroAction == 32)
                                                {
                                                    Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action AbattreUnArbre");
                                                    actionRealisee = false;
                                                }
                                                else
                                                {   if (numeroAction == 33 && chat._Fonction is Batisseur) //Miner
                                                    {
                                                        Batisseur batisseur = fonction as Batisseur;
                                                        batisseur.AllerActivite(chat, listeBatiments[2]);
                                                        batisseur.Miner(listeRessources, chat);
                                                    }
                                                    else
                                                    {   if (numeroAction == 33)
                                                        {
                                                            Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Miner");
                                                            actionRealisee = false;
                                                        }
                                                        else
                                                        {   if (numeroAction == 4 && chat._Fonction is Patissier) //Faire un gateau (patisser)
                                                            {
                                                                Patissier patissier = fonction as Patissier;
                                                                patissier.AllerActivite(chat, listeBatiments[3]);
                                                                patissier.Patisser(listeRessources[1] as Gateaux, chat);
                                                            }
                                                            else
                                                            {   if (numeroAction == 4)
                                                                {
                                                                    Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Patisser");
                                                                    actionRealisee = false;
                                                                }
                                                                else
                                                                {   if (numeroAction == 5 && chat._Fonction is Pecheur) //Pecher
                                                                    {
                                                                        Pecheur pecheur = fonction as Pecheur;
                                                                        pecheur.AllerActivite(chat, listeBatiments[9]);
                                                                        pecheur.Pecher(listeRessources[2] as Poissons, chat);
                                                                    }
                                                                    else
                                                                    {   if (numeroAction == 5)
                                                                        {
                                                                            Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Pecher");
                                                                            actionRealisee = false;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (actionRealisee == true)
            {
                compteurAction += 1;
            }
            return compteurAction;
        }

        public static int FaireActionBasique(int numeroAction, Chats chat, Fonction fonction, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<Chats> listeChats, Carte map, int compteurAction)
        {
            bool actionRealisee = true;
            if (numeroAction == 1) //Se nourrir
            {
                Console.WriteLine("Que voulez-vous que votre chat mange ? \n1 : Fruit \n2 : Gateaux \n3 : Poissons");
                int numNourriture = int.Parse(Console.ReadLine()) - 1;
                chat.PositionChat = listeBatiments[1].PositionBatiment;
                chat.Manger(listeRessources[numNourriture] as RessourceAlimentaire);
            }
            else
            {
                if (numeroAction == 2) //Se reposer
                {
                    chat.PositionChat = listeBatiments[4].PositionBatiment;
                    chat.SeReposer();
                }
                else
                {
                    if (numeroAction == 3) //Se divertir
                    {
                        Console.WriteLine("Que voulez-vous utiliser comme ressources pour que votre chat se divertisse ? \n1 : Film \n2 : Livre");
                        int numDivertissement = int.Parse(Console.ReadLine()) + 4;
                        chat.SeDivertir(listeRessources[numDivertissement] as RessourceCulturelle);
                    }
                    else
                    {
                        if (numeroAction == 4) //Changer le nom  d'un chat
                        {
                            Console.WriteLine("Voici la liste de vos chats, quel nom voulez-vous changer ?");
                            AfficherChats(listeChats);
                            int numChats = int.Parse(Console.ReadLine()) -1;
                            Console.WriteLine("Quel nom voulez-vous lui donner ?");
                            listeChats[numChats].Nom = Console.ReadLine();
                            actionRealisee = false;
                        }
                        else
                        {
                            if(numeroAction==5) //Afficher les différents niveau du chat en train de jouer
                            {
                                chat.AfficherNiveaux();
                                actionRealisee = false;
                            }
                        }
                    }
                }
            }
            if (actionRealisee == true)
            {
                compteurAction += 1;
            }
            return compteurAction;

        }



        public static int FaireActionPnj(int numeroAction, Chats chat, Fonction fonction, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<PnJ> listePnj, Carte map, int compteurAction)
        {
            bool actionRealisee = true;
            if (numeroAction == 6 && map.Map[12, 18] == "Inf") //Se faire soigner
            {
                Guerisseur guerisseur = listePnj[0] as Guerisseur;
                guerisseur.AllerActivite(chat, listeBatiments[6]);
                guerisseur.Soigner(chat);
            }
            else
            {
                if (numeroAction == 6)
                {
                    Console.WriteLine("Attention ! Vous devez d'abord débloquer le chat guérisseur en construisant l'infirmerie pour réaliser l'action Soigner");
                    actionRealisee = false;
                }
                else
                {
                    if (numeroAction == 7 && map.Map[8, 18] == "  Po") //Recevoir une ressource par le messager
                    {
                        Messager messager = listePnj[1] as Messager;
                        messager.AllerActivite(chat, listeBatiments[7]);
                        messager.Livrer(listeRessources, chat);
                    }
                    else
                    {
                        if (numeroAction == 7)
                        {
                            Console.WriteLine("Attention ! Vous devez d'abord débloquer le chat messager en construisant le bureau de poste pour réaliser l'action Livrer");
                            actionRealisee = false;
                        }
                    }
                }
            }
            if (actionRealisee == true)
            {
                compteurAction += 1;
            }
            return compteurAction;
        }
    }
}




