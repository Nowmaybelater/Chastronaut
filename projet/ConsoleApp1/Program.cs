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
            bool veutJouer = true; // initialisée à true, le booléen sert de paramètre à la fonction PresenterJeu
            bool rejouer = false; //initialisée à false, le booléen sert de condition à la boucle do....while (voir ligne 25-31)
            string nomColonie = PresenterJeu(ref veutJouer);
            do //on commence une partie
            {
                List<Ressources> listeRessources = CreerListeRessources();//Création liste de ressources et remplissage
                List<Chats> listeChats = CreerListeChats();//Création liste des Chats et remplissage
                List<Batiments> listeBatiments = new List<Batiments> { };//Création de la liste de batiments
                List<PnJ> listePnj = CreerListePnJ();//Création liste des Pnjs et remplissage
                rejouer = false; //on remet la valeur de rejouer à false pour qu'elle soit toujours fausse en début de partie
                Carte carte = InitialiserCarte(listeRessources, listeBatiments); //Création de la carte et remplissage de celle-ci avec la fonction InitialiserCarte, cette fonction permet aussi de remplir listeBatiment
                FaireDesTours(listeChats, carte, listeRessources, listeBatiments, listePnj, nomColonie); //On utilise la procédure FaireDesTours qui s'occupe de gérer tous les tours de jeux jusqu'à un gameover ou la fin de la partie.
                //Un fois la partie finie
                Console.WriteLine("Voulez-vous refaire une partie ? (OUI ou NON)"); //demande au joueur si il veut rejouer
                string reponse = Console.ReadLine();// sa réponse est récupérer dans le string reponse
                if(reponse=="OUI")
                {
                    rejouer = true; //si reponse vaut "OUI" on change la valeur de rejouer à true
                }
            } while (rejouer == true); //suivant si le joueur à répondu OUI ou NON la boucle continue ou non
            Console.ReadLine();//fin du Main
        }

        //La fonction suivante gère l'expérience d'accueil du joueur
        public static string PresenterJeu(ref bool veutJouer)
        {
            veutJouer = true; //booléen utile dans le programme principal : selon la valeur de veutJouer, une partie se relance ou pas
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(" \n ======================= ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("BIENVENUE SUR LE JEU CHASTRONAUTES !");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" ======================= \n ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Pour une meilleure expérience de jeu, pensez à afficher la console en plein écran ! \n");

            Console.WriteLine(" \n Voulez-vous afficher l'histoire ? (tapez NON pour passer, appuyez sur la touche entrée sinon)");
            string afficheHistoire = Console.ReadLine();
            if (afficheHistoire != "NON")//affichage de l'histoire 
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(" \n ===================================== ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("HISTOIRE ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("===================================== \n ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Sur une charmante planète, dans une galaxie éloignée de la notre, " +
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

                //affichage des règles du jeu 
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(" \n =================================== ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("REGLES DU JEU ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("=================================== \n ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Au cours de la partie, vous allez devoir aider les Chastronautes à survivre le temps" +
                    "\n que leur appareil de communication soit réparé. A chaque tour, vous incarnez " +
                    "\n l'un des Chastronautes, représenté sur la carte par un carré violet. Chacun des " +
                    "\n Chastronautes que vous incarnez possède un rôle particulier : bâtisseur, pêcheur, " +
                    "\n agriculteur, artiste ou pâtissier. Pendant un tour, vous devez effectuer 5 actions " +
                    "\n avec le Chastronaute que vous incarnez, actions qui dépendent du rôle du personnage. " +
                    "\n Une fois les 5 actions réalisées, un nouveau tour commence, au cours duquel vous incarnez " +
                    "\n un nouveau Chastronaute. Selon vos stratégies de jeu, vous incarnerez entre" +
                    "\n 5 et 9 des Chastronautes. Il existe également un messager et un guérisseur : ce sont des " +
                    "\n Personnages non Joueurs, ce qui signifie que vous pouvez les débloquer et interagir avec " +
                    "\n eux mais que vous ne pourrez pas enrôler. Pour remporter la partie, vous devez vous " +
                    "\n assurer de maintenir les niveaux de faim, de divertissement et de repos de chacun " +
                    "\n des personnages que vous incarnerez. Attention cependant aux extraterrestres qui, " +
                    "\n voyant que les Chastronautes tardent à repartir, lancent des attaques pour tenter " +
                    "\n de les chasser de la planète !");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(" \n ====================================================================================== \n ");
                Console.ForegroundColor = ConsoleColor.White;
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
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" \n ====================================================================================== \n ");
            Console.ForegroundColor = ConsoleColor.White;
            return (nomColonie);

        }


        //La fonction suivante gère un tour du jeu, elle fait faire 5 actions au joueur en vérifiant à chaque fois qu'il ne se retrouve pas en gameover
        public static bool FaireUnTour(List<Chats> listeChats, int chatJoue, Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<PnJ> listePnj, ref int compteurTour, string nomColonie)
        {

            Chats chatCourant = listeChats[chatJoue]; //on crée le chat qui est en train d'être joué à partir de la listeChats
            int compteurAttaque = 0; //permet d'assurer un maximum de une attaque d'extraterrestre par tour
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" \n ====================================== ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("TOUR n°{0} ", compteurTour + 1);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("====================================== \n ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nVous commencez le tour numéro {0}, \n\nVous incarnez actuellement {2} le chat {1} \n\nComme à chaque tour, vous allez pouvoir réaliser un total de 5 actions.\n\nN'oubliez de veiller au bon état de santé de votre chat durant ce tour.", compteurTour+1, chatCourant.Fonction.Nom, chatCourant.Nom);
            Console.WriteLine("Voici votre carte de jeux :\n");
            bool estAttaque = false; //pour l'affichage de la carte (false indique pas d'extraterrestre).
            AfficherCarte(map, chatCourant, listeChats, estAttaque);
            int compteurAction = 0; //permet de faire réaliser 5 actions au joueur sur un tour           
            bool seProtege = false;//est passé à true grâce à ProposerAction, permet de faire faire deux activités aux chats en automatique car se protéger compte comme une action
            bool gameover = false;//est passé à true si un des chats de la colonie a un niveau à zéro, si gameover est true la le tour et la partie s'arrête (ligne 140)
            bool estSoigne = false;//estSoigne est utiliser dans FaireActionPnj et assure que le joueur ne peut pas utiliser le guérisseur (une fois celui ci débloqué) plus d'une fois par tour
            while (compteurAction<5 && gameover==false)//un tour est constitué de 5 actions à part si l'on se retrouve en gameover
            { 
                compteurAttaque =ProposerAction(chatCourant, map, listeRessources, listeBatiments, listeChats, listePnj, ref compteurAction, compteurAttaque, ref estAttaque, ref seProtege, compteurTour+1, ref estSoigne);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n======================================================================================================================================================\n");
                Console.ForegroundColor = ConsoleColor.White;
                AfficherCarte(map, chatCourant, listeChats, estAttaque);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n======================================================================================================================================================\n");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < listeChats.Count; i++)
                {
                    if (i != chatJoue && (listeChats[i].Fonction is Guerisseur) == false && (listeChats[i].Fonction is Messager) == false)//les chats pnj ne sont pas joués, il n'y a donc pas de nécessité de les faire jouer
                    {
                        Metier metier = listeChats[i].Fonction as Metier;
                        if (seProtege == true)
                        {
                            metier.AgirAutomatiquement(listeChats[i], listeRessources, compteurAction - 1);//le chat fait une première action automatique qui correpond à l'action SeProteger réaliser par la chat courant
                            metier.AgirAutomatiquement(listeChats[i], listeRessources, compteurAction);//le chat va agir automatiquement une deuxième fois, cet action va correspondre à l'action que le chat courant devait réaliser originellement
                        }
                        else
                        {
                            metier.AgirAutomatiquement(listeChats[i], listeRessources, compteurAction);

                        }
                    }
                }
                seProtege = false;//on remet la valeur de seProtege à false pour le prochain tour

                //gestion du game over
                int numChat = 0;
                int numChatMort = 0;
                while (numChat != listeChats.Count - 1)//vérifie si tous les chats ont tous leurs niveaux au dessus de zéro
                {
                    if (listeChats[numChat].NiveauDeFaim == 0)
                    {
                        gameover = true;
                        numChatMort = numChat;
                    }
                    if (listeChats[numChat].NiveauDivertissement == 0)
                    {
                        gameover = true;
                        numChatMort = numChat;
                    }
                    if (listeChats[numChat].NiveauEnergie == 0)
                    {
                        gameover = true;
                        numChatMort = numChat;
                    }
                    numChat += 1;
                }
                if (gameover == true)//si il y a gameover, le jeu s'arrête 
                {
                    string message = "\n Vous n'avez malheureusement pas réussi à garder l'entièreté de votre colonie en vie. \n Votre chat " + listeChats[numChatMort].Nom + " a atteint un niveau  de santé critique";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" \n ==================================================================================== ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" \n                                     GAME OVER !!! ");
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("===================================================================================== \n ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            //gestion du récapitulatif à la fin d'un tour
            if (gameover == false)// pas de gameover donc on lui propose un récapitulatif de son tour
            {
                Console.WriteLine("Vous êtes arrivé à la fin de ce tour, voulez-vous un récapitulatif des ressources et de l'état de santé de vos chats avant de commencer le tour suivant ? (Entrez OUI ou NON)");

            }
            else
            {
                Console.WriteLine("Vous êtes arrivé à la fin du jeu, voulez-vous un récapitulatif des ressources et de l'état de santé de vos chats ? (Entrez OUI ou NON)");
            }
            string recap = "";
            do
            {
                recap = Console.ReadLine();
                if (recap == "OUI")
                {
                    AfficherRessources(listeRessources);
                    foreach(Chats chat in listeChats)
                    {
                        Console.WriteLine(chat.Nom + " le chat " + chat.Fonction.Nom);
                        chat.AfficherNiveaux();
                    }
                }
                else
                {
                    if (recap != "NON")
                    {
                        Console.WriteLine("\nAttention vous devez entrer OUI ou NON, toute autre entrée ne peut être prise en compte.\n");
                        Console.WriteLine("Voulez-vous un récapitulatif ?");
                    }
                }
            } while (recap != "OUI" && recap != "NON");
            return gameover;//le variable gameover est retournée
        }


        //La fonction suivante gère l'enchaînement des tours lors d'une partie, cet enchaînements'arrête si le joueur est en gameover
        public static void FaireDesTours(List<Chats> listeChats, Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<PnJ> listePnj, string nomColonie)
        {            
            int compteurTour = 0; //utilisé dans FAireUnTour
            bool gameover = false; //utilisé et retourné par FaireUnTour
            int i = 0;//utilisé pour parcourir la liste des chats
            do
            {
                if ((listeChats[i].Fonction is Guerisseur) == false && (listeChats[i].Fonction is Messager) == false)
                {
                    gameover = FaireUnTour(listeChats, i, map, listeRessources, listeBatiments, listePnj, ref compteurTour, nomColonie);//faitt faire un tour à tous les chats non pnjs 
                    compteurTour += 1;
                }
                i += 1;
            } while (i < listeChats.Count && gameover != true); //boucle continue jusqu'à ce que tous les chats aient joué ou que le joueur soit en gameover
            if(gameover!=true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(" \n ============================================================================ ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nFélicitations ! Vous avez réussi à aider les Chastronautes de la colonie {0}"+
                                  "\n     à reprendre leur voyage sans perdre aucun membre de leur équipage !", nomColonie);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(" \n ============================================================================ ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //La fonction suivante créée une liste contenant chacune des ressources ainsi que leur quantité initiale 
        public static List<Ressources> CreerListeRessources()
        {
            Bois bois = new Bois(6);
            Pierres pierre = new Pierres(6);
            Fruits fruit = new Fruits(6);
            Gateaux gateau = new Gateaux(4);
            Poissons poisson = new Poissons(5);
            Films film = new Films(6);
            Livres livre = new Livres(6);
            Graines graine = new Graines(3);
            Graines grainePlantee = new Graines(5);//grainePlantee a pour quantité le nombre de graine plantées au tour précédant, il est initialisé à 5 en début de partie.
            List<Ressources> listeRessources = new List<Ressources> { fruit, gateau, poisson, bois, pierre, film, livre, graine, grainePlantee}; //grainePlantee a pour quantité le nombre de graine plantées au tour précédant, il est initialisé à 5 en début de partie.
            return listeRessources;
        }

        //La fonction suivante créée une liste contenant  les Personnages Non Joueurs
        public static List<PnJ> CreerListePnJ()
        {
            PnJ guerisseur = new Guerisseur();
            PnJ messager = new Messager();
            List<PnJ> listePnj = new List<PnJ> { guerisseur, messager}; 
            return listePnj;
        }

        //La fonction suivante créée une liste contenant  les Personnages Non Joueurs
        public static List<Chats> CreerListeChats()
        {
            Batisseur batisseur1 = new Batisseur();
            Chats chatBatisseur1 = new Chats("Chat1", batisseur1, 10, 10, 10);
            Agriculteur agriculteur1 = new Agriculteur();
            Chats chatAgriculteur1 = new Chats("Chat2", agriculteur1, 10, 10, 10);
            Artiste artiste = new Artiste();
            Chats chatArtiste = new Chats("Chat3", artiste, 10, 10, 10);
            Batisseur batisseur2 = new Batisseur();
            Chats chatBatisseur2 = new Chats("Chat4", batisseur2, 10, 10, 10);
            Patissier patissier = new Patissier();
            Chats chatPatissier = new Chats("Chat5", patissier, 10, 10, 10);
            List<Chats> listeChats = new List<Chats> { chatBatisseur1, chatAgriculteur1, chatArtiste, chatBatisseur2, chatPatissier};
            return listeChats;
        }

        //La fonction suivante simule les vols de faim, d'énergie et de divertissement effectués par les aliens lors d'une attaque sur un chat 
        public static void SubirAttaque(Chats chat, Extraterrestre ET)
        {
            ET.VolerFaim(chat);
            ET.VolerEnergie(chat);
            ET.VolerDivertissement(chat);

            Console.WriteLine("Vous avez été attaqué ! Votre Chastronaute a perdu 2 points de Faim, 2 points d'Energie et 2 points de Divertissement ");
        }

        //La fonction suivante gère le processus complet d'attaque par un alien
        public static int SeFaireAttaquer(Chats chat, int compteurAttaque, ref int compteurAction, Carte carte, List<Chats> listeChats, ref bool estAttaque, ref bool seProtege)
        {
            if(compteurAttaque==0)//le varieblee compteur attaque est réutilisée dans ProposerAction afin d'assurer que le joueur ne se fiat pas attaquer plus d'une fois par tour
            {
                Random rnd = new Random();
                int intervention = rnd.Next(1, 6);
                if (intervention == 1)//attaque aléatoire de l'extraterrestre
                {
                    Extraterrestre ET = new Extraterrestre();
                    ET.AllerActivite(chat, chat.PositionChat);
                    AfficherCarte(carte, chat, listeChats, true);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" \n =================================== ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("ATTENTION ! ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" =================================== ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nVous êtes sur le point de vous faire attaquer par un extraterrestre, deux choix s'offrent à vous :\n 1 : Se protéger et perdre une action sur le tour\n 2 : Ne pas de se protéger et perdre 2 points dans chaque niveau de santé");//donc le joueur perdrait un point de NiveauFai, un point de NiveauDivertissement et un point de NiveauEnergie si il ne se protège pas.
                    estAttaque = true;//varirable utilisée pour le afficher carte
                    int reponse = 0;
                    do
                    {
                        Console.WriteLine("Que voulez-vous faire ?");
                        reponse = int.Parse(Console.ReadLine());
                        if (reponse == 2)
                        {
                            SubirAttaque(chat, ET);
                            compteurAttaque += 1;                           
                        }
                        else
                        {
                            if (reponse == 1)
                            {
                                compteurAction += 1;
                                compteurAttaque += 1;
                                seProtege = true;
                                Console.WriteLine("Vous vous êtes bien protégé !");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("\n ============================================================================== \n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.WriteLine("\nAttention, vous devez rentrer une valeur entre 1 et 2 !\n"); //assure une bonne entrée du joueur
                            }
                        }
                    } while (reponse!=1 && reponse!=2);
                    estAttaque = false;//on réinitialise estAttaque à la valeur false pour l'affiche de le carte de la prochaine action
                }                
            }
            return compteurAttaque;
        }

        //La fonction suivante permet la génération de la carte de jeu
        public static Carte InitialiserCarte(List<Ressources> listeRessources, List<Batiments> listeBatiments)
        {
            Carte map = new Carte();
            Bois bois = listeRessources[3] as Bois;
            Pierres pierre = listeRessources[4] as Pierres;
            Carriere carriere = new Carriere();//Création d'une carrière pour miner des pierres
            carriere.Construire(map, listeRessources,listeBatiments);

            Foret foret = new Foret();//Création d'une forêt pour abattre des arbres
            foret.Construire(map, listeRessources, listeBatiments);

            Potager potager = new Potager();//Création d'une champ d'agriculture
            potager.Construire(map, listeRessources, listeBatiments);

            Cantine cantine = new Cantine();//Création d'une cantine pour que les chats puissent manger
            cantine.Construire(map, listeRessources, listeBatiments);

            Dortoir dortoir = new Dortoir();//Création d'un dortoir pour que les chats puissent se reposer
            dortoir.Construire(map, listeRessources, listeBatiments);

            Cuisine cuisine = new Cuisine();//Création d'une cuisine pour que les chats pâtissiers puissent faire des gâteaux
            cuisine.Construire(map, listeRessources, listeBatiments);

            Atelier atelier = new Atelier();//Création d'un atelier pour que les chats artistes puissent créer du divertissement
            atelier.Construire(map, listeRessources, listeBatiments);
            return map;
        }

        //La fonction suivante permet d'afficher la carte générée grâce à la fonction précédente
        public static void AfficherCarte(Carte carte, Chats chat, List<Chats> ListeChats, bool estAttaque)// on utilise cette fonction plutôt que le ToString de Carte car cela permet un affichage avec des couleurs
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (i == chat.PositionChat[0] && j == chat.PositionChat[1])//affichage du chat enrôlé sous la forme d'un carré violet
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(carte.Map[i, j]);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        if(estAttaque==true && i == chat.PositionChat[0]-1 && j == chat.PositionChat[1]-1)//affichage de l'alien qui attaque sous la forme d'un carré vert
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(carte.Map[i, j]);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.Write(carte.Map[i, j]);
                        }
                    }
                }
                Console.Write("\n");
            }
        }


        //La fonction suivante permet d'afficher un à un les éléments de la liste de ressources
        public static void AfficherRessources(List<Ressources> listeRessources)//affiche toutes les ressources
        //ListeRessources rassemble toutes les ressources, la place de la ressource dans la liste correspond à son attribut numéro
        {
            for(int i=0; i<listeRessources.Count-1;i++)//on n'affiche pas la dernière ressource de la liste qui permet de garder la quantité de graine planter la dernière fois en mémoire.
            {
                Console.WriteLine(listeRessources[i]);
            }
        }


        //La fonction suivante permet d'afficher un à un les éléments de la liste de chats
        public static void AfficherChats(List<Chats> listeChats)//affiche tous les chats
        {
            int i = 1;
            foreach (Chats chat in listeChats)
            {
                Console.WriteLine(i+":"+chat);
                i += 1;
            }
        }



        //La fonction suivante permet de faire réaliser des actions au joueur, cette fonction gère les action que l'ont trouve dans les méthodes des classes filles de métier
        public static int FaireActionMetier(int numeroAction, Chats chat, Fonction fonction, List<Ressources> listeRessources, List<Batiments> listeBatiments, Carte map, ref int compteurAction, List<Chats> listeChats, List<PnJ> listePnj)
        //ajouter le fait qu'il puisse se faire attaquer par extraterrestre
        //rajouter test si list pnj vide
        {
            bool actionRealisee = true;//utilisé pour le compteur d'action, permet de compter où non l'action suivatn sa nature et si le joueur à réaliser une entrée valide en choisissant son action
            if (numeroAction == 11 && chat.Fonction is Agriculteur) //Recolter
            {//toujours trois étape minimum par action
                Agriculteur agriculteur = fonction as Agriculteur; // 1 : créer le métier avec as
                agriculteur.AllerActivite(chat, listeBatiments[2]);// 2 : Envois le chat à la bonne position sur la carte
                agriculteur.Recolter(chat, listeRessources, true);// 3 : Lui fait faire l'action
                // 4 : potentiel affichage et/ou décisions à prendre par le joueur
            }
            else
            {   if (numeroAction == 11)//comme à chaque autre action on si le joueur choisi une action non réalisable par son chat on lui indique, l'action n'est pas compté et on lui propose d'en choisir une autre
                {
                    Console.WriteLine("\nAttention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Récolter\n");
                    actionRealisee = false;
                }
                else
                {   if (numeroAction == 12 && chat.Fonction is Agriculteur) //Planter
                    {
                        Agriculteur agriculteur = fonction as Agriculteur;
                        agriculteur.AllerActivite(chat, listeBatiments[2]);//la place des batiments dans la liste dépends de la liste créer par InitialiserCarte()
                        listeRessources[8].Quantite += agriculteur.Planter(chat, listeRessources[7] as Graines, true);
                    }
                    else
                    {   if (numeroAction == 12)
                        {
                            Console.WriteLine("\nAttention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Planter\n");
                            actionRealisee = false;
                        }
                        else
                        {
                            if (numeroAction == 21 && chat.Fonction is Artiste) //Creer
                            {//cette action est identifier par le numero 21 pour le différencier de l'action 2 dans FaireActionBasique                                
                                Artiste artiste = fonction as Artiste;
                                artiste.AllerActivite(chat, listeBatiments[6]);
                                int numRessourceCulturelle = 0;
                                do
                                {
                                    Console.WriteLine("Que voulez-vous créer ?  \n1 : Film \n2 : Livre");
                                    numRessourceCulturelle = int.Parse(Console.ReadLine());
                                    if (numRessourceCulturelle == 1)
                                    {
                                        artiste.Creer(chat, listeRessources[5] as RessourceCulturelle);
                                        Console.WriteLine("Vous venez de créer 4 films, voici l'inventaire de vos ressources culturelles : \n" + listeRessources[5] + listeRessources[6]);
                                    }
                                    else
                                    {
                                        if(numRessourceCulturelle==2)
                                        {
                                            artiste.Creer(chat, listeRessources[6] as RessourceCulturelle);
                                            Console.WriteLine("Vous venez de créer 4 livres, voici l'inventaire de vos ressources culturelles : \n" + listeRessources[5] + listeRessources[6]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nAttention vous devez entrer un nombre entre 1 et 2.\n");
                                        }
                                    }
                                } while (numRessourceCulturelle != 1 && numRessourceCulturelle != 2); //assure une entrée valide du joueur                               
                            }
                            else
                            {   if (numeroAction == 21)
                                {
                                    Console.WriteLine("\nAttention ! Vous devez jouer en tant que chat artiste pour réaliser l'action Créer\n");
                                    actionRealisee = false;
                                }
                                else
                                {   if (numeroAction == 31 && chat.Fonction is Batisseur) //Construire
                                    {
                                        FaireActionConstruire(map, fonction, actionRealisee, listeRessources, listeChats, chat, listeBatiments, listePnj);//allège le code
                                    }
                                    else
                                    {   if (numeroAction == 31)
                                        {
                                            Console.WriteLine("\nAttention ! Vous devez jouer en tant que chat Bâtisseur pour réaliser l'action Construire\n");
                                            actionRealisee = false;
                                        }
                                        else
                                        {   if (numeroAction == 32 && chat.Fonction is Batisseur) //Abattre un arbre
                                            {
                                                Batisseur batisseur = fonction as Batisseur;
                                                batisseur.AllerActivite(chat, listeBatiments[1]);
                                                batisseur.AbattreUnArbre(listeRessources, chat);
                                                Console.WriteLine("\nVous venez d'abattre un arbre, cela vous à permis d'ajouter 2 planches de bois en plus dans vos ressoucres.");
                                                Console.WriteLine("Voici vos ressources actuelle de construction : {0} bois et {1} pierre(s)", listeRessources[3].Quantite, listeRessources[4].Quantite);
                                            }
                                            else
                                            {   if (numeroAction == 32)
                                                {
                                                    Console.WriteLine("\nAttention ! Vous devez jouer en tant que chat Bâtisseur pour réaliser l'action AbattreUnArbre\n");
                                                    actionRealisee = false;
                                                }
                                                else
                                                {   if (numeroAction == 33 && chat.Fonction is Batisseur) //Miner
                                                    {
                                                        Batisseur batisseur = fonction as Batisseur;
                                                        batisseur.AllerActivite(chat, listeBatiments[0]);
                                                        batisseur.Miner(listeRessources, chat);
                                                        Console.WriteLine("\nVous venez de miner, cela vous a permis d'ajouter 2 unité de pierre en plus dans vos ressources.");
                                                        Console.WriteLine("Voici vos ressources actuelles de construction : {0} bois et {1} pierres", listeRessources[3].Quantite, listeRessources[4].Quantite);
                                                    }
                                                    else
                                                    {   if (numeroAction == 33)
                                                        {
                                                            Console.WriteLine("\nAttention ! Vous devez jouer en tant que chat Bâtisseur pour réaliser l'action Miner\n");
                                                            actionRealisee = false;
                                                        }
                                                        else
                                                        {   if (numeroAction == 41 && chat.Fonction is Patissier) //Faire un gateau (patisser)
                                                            {
                                                                Patissier patissier = fonction as Patissier;
                                                                patissier.AllerActivite(chat, listeBatiments[5]);
                                                                patissier.Patisser(listeRessources[1] as Gateaux, chat);
                                                                Console.WriteLine("\nVous venez de faire 3 gâteaux, voici l'inventaire de vos ressources alimentaires : \n" + listeRessources[0] + listeRessources[1] + listeRessources[2]);
                                                            }
                                                            else
                                                            {   if (numeroAction == 41)
                                                                {
                                                                    Console.WriteLine("\nAttention ! Vous devez jouer en tant que chat Pâtissier pour réaliser l'action Patisser\n");
                                                                    actionRealisee = false;
                                                                }
                                                                else
                                                                {   if (numeroAction == 51 && chat.Fonction is Pecheur && map.Map[2,46] == " Zo") //Pecher, si la zone de peche a été construite
                                                                    {
                                                                        Pecheur pecheur = fonction as Pecheur;
                                                                        int placeZoneDePeche = 0;
                                                                        for (int i = 6; i < listeBatiments.Count;i++)
                                                                        {
                                                                            if(listeBatiments[i] is ZoneDePeche)
                                                                            {
                                                                                placeZoneDePeche = i;
                                                                            }
                                                                        }
                                                                        pecheur.AllerActivite(chat, listeBatiments[placeZoneDePeche]);
                                                                        pecheur.Pecher(listeRessources[2] as Poissons, chat);
                                                                        Console.WriteLine("\nVous avez pêché 5 poissons.\nVoici vos ressources alimentaires.");
                                                                        Console.WriteLine(listeRessources[0] + "" + listeRessources[1] + listeRessources[2]+ " ");
                                                                    }
                                                                    else
                                                                    {   if (numeroAction == 51)
                                                                        {
                                                                            Console.WriteLine("\nAttention ! Vous devez jouer en tant que chat Pêcheur pour réaliser l'action Pecher\n");
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
            if (actionRealisee == true)//augmente le compteur d'action si une action a été réalisée
            {
                compteurAction += 1;
            }
            return compteurAction;
        }


        //La fonction suivante permet de faire réaliser l'action construire aux chats batisseurs
        public static void FaireActionConstruire(Carte map, Fonction fonction, bool actionRealisee, List<Ressources> listeRessources, List<Chats> listeChats, Chats chat, List<Batiments> listeBatiments, List<PnJ> listePnj)
        {
            if (map.Map[12, 18] != "Inf" && map.Map[8, 18] == "  Po" && map.Map[7, 5] == " Po" && map.Map[2, 46] == " Zo")//vérifie si tous les batiments ont déjà été construit
            {
                Console.WriteLine("Vous avez déjà construit tous le bâtiments qu'un chat batisseur peut construire sur la carte choisissez une autre activité");
                actionRealisee = false;
            }
            else
            {

                Console.WriteLine(listeRessources[3] + "\n" + listeRessources[4]);//gère l'affichage pour n'afficher que les batiments non construits
                Console.WriteLine("\nQue voulez-vous construire ?");
                if (map.Map[12, 18] != "Inf")
                {
                    Console.WriteLine("1 : Infirmerie (nécessite 1 bois et 1 pierre)");
                }
                if (map.Map[8, 18] != "  Po")
                {
                    Console.WriteLine("2 : Poste (nécessite 1 bois et 1 pierre)");
                }
                if (map.Map[7, 5] != " Po")
                {
                    Console.WriteLine("3 : Potager (nécessite 2 bois)");
                }
                if (map.Map[2, 46] != " Zo")
                {
                    Console.WriteLine("4 : Zone de pêche (nécessite 2 pierres)");
                }
                Console.WriteLine("5 : Voir mes ressources");
                int numConstruction = 0;
                bool numConsCorrect = false;
                do
                {
                    numConstruction = int.Parse(Console.ReadLine()) + 6;// on ajoute 6 pour avoir le numéro entrée par le joueur correspondant au numéro du batiment recherché.
                    if (numConstruction == 11)//5+6 : action voir ressources
                    {
                        if (map.Map[12, 18] != "Inf" && map.Map[8, 18] == "  Po" && map.Map[7, 5] == " Po" && map.Map[2, 46] == " Zo")
                        {
                            Console.WriteLine("Vous avez déjà construit tous le bâtiments qu'un chat batisseur peut construire sur la carte choisissez une autre activité");
                        }
                        else
                        {
                            Console.WriteLine(listeRessources[3] + "\n" + listeRessources[4]);
                            Console.WriteLine("\nQue voulez-vous construire ?");
                            if (map.Map[12, 18] != "Inf")
                            {
                                Console.WriteLine("1 : Infirmerie (nécessite 1 bois et 1 pierre)");
                            }
                            if (map.Map[8, 18] != "  Po")
                            {
                                Console.WriteLine("2 : Poste (nécessite 1 bois et 1 pierre)");
                            }
                            if (map.Map[7, 5] != " Po")
                            {
                                Console.WriteLine("3 : Potager (nécessite 2 bois)");
                            }
                            if (map.Map[2, 46] != " Zo")
                            {
                                Console.WriteLine("4 : Zone de pêche (nécessite 2 pierres)");
                            }
                            numConstruction = int.Parse(Console.ReadLine()) + 6;// on ajoute 6 pour avoir le numéro entrée par le joueur correspondant au numéro du batiment recherché.
                            if (numConstruction >= 7 && numConstruction <= 10)//gère une mauvaise entrée potetiel (le joueur veut construire un batiment déjà existant
                            {
                                if (map.Map[12, 18] == "Inf" && numConstruction == 7)
                                {
                                    numConsCorrect = false;
                                }
                                else
                                {
                                    if (map.Map[8, 18] == "  Po" && numConstruction == 8)
                                    {
                                        numConsCorrect = false;
                                    }
                                    else
                                    {
                                        if (map.Map[7, 5] == " Po" && numConstruction == 9)
                                        {
                                            numConsCorrect = false;
                                        }
                                        else
                                        {
                                            if (map.Map[2, 46] == " Zo" && numConstruction == 10)
                                            {
                                                numConsCorrect = false;
                                            }
                                            else
                                            {
                                                numConsCorrect = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else//affichage change si voir ressources pas demandé
                    {
                        if (numConstruction >= 7 && numConstruction <= 11)
                        {
                            if (map.Map[12, 18] == "Inf" && numConstruction == 7)
                            {
                                numConsCorrect = false;
                            }
                            else
                            {
                                if (map.Map[8, 18] == "  Po" && numConstruction == 8)
                                {
                                    numConsCorrect = false;
                                }
                                else
                                {
                                    if (map.Map[7, 5] == " Po" && numConstruction == 9)
                                    {
                                        numConsCorrect = false;
                                    }
                                    else
                                    {
                                        if (map.Map[2, 46] == " Zo" && numConstruction == 10)
                                        {
                                            numConsCorrect = false;
                                        }
                                        else
                                        {
                                            numConsCorrect = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (numConsCorrect == false)
                    {
                        Console.WriteLine("\nAttention le numéro entré est incorrect. Veuillez réessayer : ");
                    }
                } while (numConsCorrect == false);
                Batisseur batisseur = fonction as Batisseur;
                batisseur.Construire(numConstruction, map, chat, listeRessources, listeBatiments, listeChats, listePnj);//Réalise l'action Construire
            }
        }



        //La fonction suivante permet de faire réaliser des actions au joueur, cette fonction gère les action basique tel que manger ou se reposer
        public static int FaireActionBasique(int numeroAction, Chats chat, Fonction fonction, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<Chats> listeChats, Carte map, ref int compteurAction)
        {
            bool actionRealisee = true;//utilisé pour le compteur d'action, permet de compter où non l'action suivatn sa nature et si le joueur à réaliser une entrée valide en choisissant son action
            if (numeroAction == 1) //Se nourrir
            {
                int numNourriture = 0;
                int quantiteNourriture = 0;
                if(listeRessources[0].Quantite==0 && listeRessources[1].Quantite == 0 && listeRessources[2].Quantite == 0)
                {
                    Console.WriteLine("\n Attention ! Vous n'avez plus de nourriture !\n");
                    actionRealisee = false;
                }
                else
                {
                    do//vérifie que la nourriture demandé existe
                    {
                        do//vérifie le numéro entré par le joueur
                        {
                            Console.WriteLine("\nQue voulez-vous que votre chat mange ? \n1 : Fruit (quantité : {0}) \n2 : Gateaux (quantité : {1}) \n3 : Poissons (quantité : {2}) ", listeRessources[0].Quantite, listeRessources[1].Quantite, listeRessources[2].Quantite);
                            numNourriture = int.Parse(Console.ReadLine()) - 1;
                            if (numNourriture != 0 && numNourriture != 1 && numNourriture != 2)
                            {
                                Console.WriteLine("\nAttention ! Vous devez entrer un nombre entre 1 et 3\n");
                            }
                        } while (numNourriture != 0 && numNourriture != 1 && numNourriture != 2);
                        quantiteNourriture = listeRessources[numNourriture].Quantite;
                        chat.PositionChat = listeBatiments[3].PositionBatiment;
                        if(quantiteNourriture != 0)//changement d'affichage si quantité nourriture nulle ou non
                        {
                            chat.Manger(listeRessources[numNourriture] as RessourceAlimentaire);
                            Console.WriteLine("\nVous venez de manger un {0}", listeRessources[numNourriture].Nom);
                            Console.WriteLine("\n{0} a à présent un niveau de faim de {1}", chat.Nom, chat.NiveauDeFaim);
                        }
                        else
                        {
                            Console.WriteLine("\nVous n'avez plus de cette nourriture !");
                        }
                    } while (quantiteNourriture == 0);
                }
            }
            else
            {
                if (numeroAction == 2) //Se reposer
                {
                    chat.PositionChat = listeBatiments[4].PositionBatiment;
                    chat.SeReposer();
                    Console.WriteLine("\nVous venez de vous reposer au dortoir");
                    Console.WriteLine("\n{0} a à présent un niveau d'énergie de {1}", chat.Nom, chat.NiveauEnergie);
                }
                else
                {
                    if (numeroAction == 3) //Se divertir
                    {
                        int numDivertissement = 0;
                        do
                        {
                            do
                            {
                                Console.WriteLine("\nQue voulez-vous utiliser comme ressource pour que votre chat se divertisse ? \n1 : Film (quantité : {0} ) \n2 : Livre (quantité : {1} )", listeRessources[5].Quantite, listeRessources[6].Quantite);
                                numDivertissement = int.Parse(Console.ReadLine()) + 4;
                                if (numDivertissement != 5 && numDivertissement != 6)
                                {
                                    Console.WriteLine("\nAttention ! Vous devez entrer un nombre entre  1 et 2\n");
                                }
                            } while (numDivertissement != 5 && numDivertissement != 6);
                            if (listeRessources[numDivertissement].Quantite != 0)//changement d'affichage si quantité divertissement nulle ou non
                            {
                                chat.SeDivertir(listeRessources[numDivertissement] as RessourceCulturelle);
                                Console.WriteLine("\nVous venez de vous divertir avec un {0}", listeRessources[numDivertissement].Nom);
                                Console.WriteLine("\n{0} a à présent un niveau de divertissement  de {1}", chat.Nom, chat.NiveauDivertissement);
                            }
                            else
                            {
                                Console.WriteLine("\nVous n'avez plus de ce divertissemente !");
                            }
                        } while (listeRessources[numDivertissement].Quantite == 0);
                    }
                    else
                    {
                        if (numeroAction == 4) //Changer le nom  d'un chat
                        {
                            Console.WriteLine("\nVoici la liste de vos chats :");
                            AfficherChats(listeChats);
                            int numChat = 0;
                            bool numeroCorrect = false;
                            do
                            {
                                Console.WriteLine("\nQuel nom voulez - vous changer ?");
                                numChat = int.Parse(Console.ReadLine()) - 1;
                                if(numChat>=0 && numChat<=listeChats.Count-1)
                                {
                                    numeroCorrect = true;
                                }
                                if(numeroCorrect==false)
                                {
                                    Console.WriteLine("\nLe numéro entré n'est pas correct veuillez réessayer.\n");
                                }
                            } while (numeroCorrect==false);
                            Console.WriteLine("\nQuel nom voulez-vous lui donner ?");
                            listeChats[numChat].Nom = Console.ReadLine();
                            Console.WriteLine("\nVotre chat {0} a bien été renommé {1}", listeChats[numChat].Fonction.Nom, listeChats[numChat].Nom);
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



        //La fonction suivante permet de faire réaliser des actions au joueur, cette fonction gère les action réaliser par des Pnj
        public static int FaireActionPnj(int numeroAction, Chats chat, Fonction fonction, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<PnJ> listePnj, Carte map, ref int compteurAction, int compteurTour, ref bool estSoigne)
        {
            bool actionRealisee = true; //utilisé pour le compteur d'action, permet de compter où non l'action suivatn sa nature et si le joueur à réaliser une entrée valide en choisissant son action
            if (numeroAction == 6 && map.Map[12, 18] == "Inf") //Se faire soigner
            {
                Guerisseur guerisseur = listePnj[0] as Guerisseur;
                guerisseur.AllerActivite(chat, new int[] { 12, 19 });
                if(compteurTour%2==0 && estSoigne==false)//assure que le guérisseur ne soit utilisé que les tours pairs et une fois par tour
                {
                    guerisseur.Soigner(chat);
                    Console.WriteLine("\nVous venez d'aller voir le guérisseur, votre chat a donc un niveau d'énergie à 10, et avez un niveau de faim augmenté de 3 points.");
                    estSoigne = true;
                }
                else
                {
                    actionRealisee = false;
                    Console.WriteLine("\nAttention vous ne pouvez pas aller chez le guérisseur, il est en effet en congé lors des tours impairs.\n");
                }
            }
            else
            {
                if (numeroAction == 6)
                {
                    Console.WriteLine("\nAttention ! Vous devez d'abord débloquer le chat guérisseur en construisant l'infirmerie pour réaliser l'action Soigner\n");
                    actionRealisee = false;
                }
                else
                {
                    if (numeroAction == 7 && map.Map[8, 18] == "  Po") //Recevoir une ressource par le messager
                    {
                        Messager messager = listePnj[1] as Messager;
                        messager.AllerActivite(chat, new int[] { 8, 19 });
                        messager.Livrer(listeRessources, chat);
                    }
                    else
                    {
                        if (numeroAction == 7)
                        {
                            Console.WriteLine("\nAttention ! Vous devez d'abord débloquer le chat messager en construisant le bureau de poste pour réaliser l'action Livrer\n");
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

        //La fonction suivante propose au joueur une liste des actions qu'il peut réaliser (selon le rôle du personnage qu'il incarne, etc.), lui demande de choisir une de ces actions et la réalise si c'est possible (en faisant appel aux fonctions FaireAction, FaireActionMetier et FaireActionBasique) 
        public static int ProposerAction(Chats chat, Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<Chats> listeChats, List<PnJ> listePnj, ref int compteurAction, int compteurAttaque, ref bool estAttaque, ref bool seProtege, int compteurTour, ref bool estSoigne)
        {
            //Affichage de la liste des actions 
            Console.WriteLine("\nVous pouvez choisir une action à effectuer parmi la liste suivante : \n");
            List<string> listeActionPossible = new List<string> { " 1 : Se nourrir" , " 2 : Se reposer" , " 3 : Se divertir" , " 4 : Changer le nom d'un chat" , " 5 : Afficher les différents niveaux d'un chat" , " 6 : Récolter (propre au chat Agriculteur)" , " 7 : Planter (propre au chat Agriculteur)", " 8 : Construire (propre au chat Batisseur)", " 9 : Abattre un arbre (propre au chat Batisseur)", " 10 : Miner (propre au chat Batisseur)", " 11 : Patisser (propre au chat Patissier)", " 12 : Créer un divertissement (propre au chat Artiste)" };
            if (map.Map[2, 46] == " Zo")//la condition porte sur le fait que la zone de pêche soit construite
            {
                listeActionPossible.Add(" 13 : Pecher");
            }
            if (map.Map[12, 18] == "Inf")//la condition porte sur le fait que l'infirmerie soit construite
            {
                listeActionPossible.Add(" 14 : Aller voir le guérisseur ");
            }
            if(map.Map[8, 18] == "  Po")//la condition porte sur le fait que le bureau de poste soit construite
            {
                listeActionPossible.Add(" 15 : Aller voir le messager");
            }
            for(int i=0; i<listeActionPossible.Count; i++)
            {
                Console.WriteLine(listeActionPossible[i]);
            }
            //Choix de l'action à effectuer par le joueur
            bool actionRealisable = true;
            int numeroAction;
            do
            {
                actionRealisable = true; //on réinitialise le booléen à true.
                Console.WriteLine("\nChoisissez une action à effectuer : ");
                numeroAction = int.Parse(Console.ReadLine());

                //On regarde la valeur de numeroAction et on le convertit en fonction des numérotations des fonctions FaireActionMetier et FaireActionPnj
                if (numeroAction == 6)
                {
                    numeroAction = 11;
                }
                else
                {
                    if (numeroAction == 7)
                    {
                        numeroAction = 12;
                    }
                    else
                    {
                        if (numeroAction == 8)
                        {
                            numeroAction = 31;
                        }
                        else
                        {
                            if (numeroAction == 9)
                            {
                                numeroAction = 32;
                            }
                            else
                            {
                                if (numeroAction == 10)
                                {
                                    numeroAction = 33;
                                }
                                else
                                {
                                    if (numeroAction == 11)
                                    {
                                        numeroAction = 41;
                                    }
                                    else
                                    {
                                        if (numeroAction == 12)
                                        {
                                            numeroAction = 21;
                                        }
                                        else
                                        {
                                            if (numeroAction == 13 && map.Map[2, 46] == " Zo")
                                            {
                                                numeroAction = 51;
                                            }
                                            else
                                            {                                              
                                                if (numeroAction == 14 && map.Map[12, 18] == "Inf")
                                                {
                                                    numeroAction = 6;
                                                }
                                                else
                                                {                                                       
                                                    if (numeroAction == 15 && map.Map[8, 18] == "  Po")
                                                    {
                                                        numeroAction = 7;
                                                    }
                                                    else
                                                    {
                                                        if(numeroAction<1)
                                                        {
                                                            actionRealisable = false;
                                                        }
                                                        if(numeroAction>5)
                                                        {
                                                            actionRealisable = false;
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
                //boucle pour choisir la fonction à appeler parmi : FaireAction, FaireActionMetier et FaireActionBasique

                if (numeroAction >= 1 && numeroAction <= 5)
                {
                    if(numeroAction!=4 && numeroAction!=5)
                    {
                        compteurAttaque = SeFaireAttaquer(chat, compteurAttaque, ref compteurAction, map, listeChats, ref estAttaque, ref seProtege);
                    }
                    if(compteurAction!=5)
                    {
                        FaireActionBasique(numeroAction, chat, chat.Fonction, listeRessources, listeBatiments, listeChats, map, ref compteurAction);
                    }
                }
                else
                {
                    if ((numeroAction >= 11 && numeroAction <= 12) || (numeroAction >= 31 && numeroAction <= 33) || numeroAction==41 || numeroAction==21 || numeroAction == 51)
                    {
                        compteurAttaque = SeFaireAttaquer(chat, compteurAttaque, ref compteurAction, map, listeChats, ref estAttaque, ref seProtege);
                        if (compteurAction != 5)
                        {
                            FaireActionMetier(numeroAction, chat, chat.Fonction, listeRessources, listeBatiments, map, ref compteurAction, listeChats, listePnj);

                        }
                    }
                    else
                    {
                        if (numeroAction >= 6 && numeroAction <= 7)
                        {
                            compteurAttaque = SeFaireAttaquer(chat, compteurAttaque, ref compteurAction, map, listeChats, ref estAttaque, ref seProtege);
                            if (compteurAction != 5)
                            {
                                FaireActionPnj(numeroAction, chat, chat.Fonction, listeRessources, listeBatiments, listePnj, map, ref compteurAction, compteurTour, ref estSoigne);
                            }
                        }
                        else
                            Console.WriteLine("\nAttention, vous devez choisir un numéro d'action existant\n");
                    }
                }
            }while (actionRealisable==false); //boucle do...while pour redemander au joueur de choisir une action à faire tant que le numéro d'action saisi n'est pas correct           
            return compteurAttaque;
        }
    }
}