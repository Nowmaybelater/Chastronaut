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
            List<Ressources> listeRessources = CreerListeRessources();//Création liste de ressources
            List<Chats> listeChats = CreerListeChats();//Création liste des Chats
            List<Batiments> listeBatiments = new List<Batiments> {};//création de la liste de batiments
            List<PnJ> listePnj = CreerListePnJ();
            Carte carte = InitialiserCarte(listeRessources, listeBatiments, listeChats[4]);
            FaireDesTours(listeChats,carte, listeRessources, listeBatiments, listePnj);
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
                    "\n que vous pouvez débloquer mais que vous ne pourrez pas enrôler. Pour remporter" +
                    "\n la partie, vous devez vous assurer de maintenir les niveaux de faim, de " +
                    "\n divertissement et de repos de chacun des personnages que vous incarnerez." +
                    "\n Attention cependant aux extraterrestres qui, voyant que les Chastronautes" +
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

        public static bool FaireUnTour(List<Chats> listeChats, int chatJoue, Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<PnJ> listePnj, ref int compteurTour)
        {

            Chats chatCourant = listeChats[chatJoue];
            int compteurAttaque = 0;
            Console.WriteLine("\nVous commencez le tour numéro {0}, \n\nVous incarnez actuellement {2} le chat {1} \n\nComme à chaque tour, vous allez pouvoir réaliser un total de 5 actions.\n\nN'oubliez de veiller au bon état de santé de votre chat durant ce tour.", compteurTour+1, chatCourant.Fonction.Nom, chatCourant.Nom);
            int compteurAction = 0;
            bool estAttaque = false;
            bool seProtege = false;
            bool gameover = false;
            while (compteurAction<5)
            {
                for (int c = 0; c < listeChats.Count; c++)
                {
                    Console.WriteLine(listeChats[c].Nom);
                    listeChats[c].AfficherNiveaux();
                }
                compteurAttaque =ProposerAction(chatCourant, map, listeRessources, listeBatiments, listeChats, listePnj, ref compteurAction, compteurAttaque, ref estAttaque, ref seProtege);
                Console.WriteLine(chatCourant.PositionChat[0] + " " + chatCourant.PositionChat[1]);
                AfficherCarte(map, chatCourant, listeChats, estAttaque);
                for (int i = 0; i < listeChats.Count; i++)
                {
                    if (i != chatJoue && (listeChats[i].Fonction is Guerisseur) == false && (listeChats[i].Fonction is Messager) == false)
                    {
                        Metier metier = listeChats[i].Fonction as Metier;
                        metier.AgirAutomatiquement(listeChats[i], listeRessources, compteurAction);
                        if(seProtege==true)
                        {
                            metier.AgirAutomatiquement(listeChats[i], listeRessources, compteurAction);//le chat va agir automatiquement une deuxième fois car le chat s'est protéger donc le joueur à réaliser deux actions
                        }
                    }
                }
                seProtege = false;
                int numChat = 0;
                int numChatMort = 0;
                while (numChat != listeChats.Count - 1)
                {
                    if (listeChats[numChat].NiveauDeFaim == 0)
                    {
                        if (listeChats[numChat].NiveauDivertissement == 0)
                        {
                            if (listeChats[numChat].NiveauEnergie == 0)
                            {
                                gameover = true;
                                numChatMort = numChat;
                            }
                        }
                    }
                    numChat += 1;
                }
                if (gameover == true)
                {
                    string message = "GAME OVER !!! \nVous n'avez malheureusement pas réussi à garder l'entièreté de votre colonie en vie. \nVotre chat " + listeChats[numChatMort].Nom + " a atteint un niveau  de santé critique";
                    Console.WriteLine(message);
                }
            }

            Console.WriteLine("Vous êtes arrivé à la fin de ce tour, voulez-vous un récapitulatif des ressources et de l'état de santé de votre chat avant de commencer le tour suivant ? (Entrez OUI ou NON)");
            string recap = "";
            do
            {
                recap = Console.ReadLine();
                if (recap == "OUI")
                {
                    AfficherRessources(listeRessources);
                    chatCourant.AfficherNiveaux();
                }
                else
                {
                    if (recap != "NON")
                    {
                        Console.WriteLine("Attention vous devez entrer OUI ou NON, toute autre entrée ne peut être prise en compte.");
                        Console.WriteLine("Voulez-vous un récapitulatif ?");
                    }
                }
            } while (recap != "OUI" && recap != "NON");
            return gameover;
        }


        public static void FaireDesTours(List<Chats> listeChats, Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<PnJ> listePnj)
        {            
            int compteurTour = 0;
            bool gameover = false;
            int i = 0;
            do
            {
                if ((listeChats[i].Fonction is Guerisseur) == false && (listeChats[i].Fonction is Messager) == false)
                {
                    gameover = FaireUnTour(listeChats, i, map, listeRessources, listeBatiments, listePnj, ref compteurTour);
                    compteurTour += 1;
                }
                i += 1;
            } while (i < listeChats.Count && gameover != true);
            if(gameover!=true)
            {
                Console.WriteLine("Félicitation ! Vous avez réussi à aider les Chastronautes à reprendre leur voyage sans perdre aucun membre de leur équipage !");
            }
        }


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
            Graines grainePlantee = new Graines(5);
            List<Ressources> listeRessources = new List<Ressources> { fruit, gateau, poisson, bois, pierre, film, livre, graine, grainePlantee}; //grainePlantee a pour quantité le nombre de graine plantées au tour précédant, il est initialisé à 5 en début de partie.
            return listeRessources;
        }

        public static List<PnJ> CreerListePnJ()
        {
            PnJ guerisseur = new Guerisseur();
            PnJ messager = new Messager();
            List<PnJ> listePnj = new List<PnJ> { guerisseur, messager}; //grainePlantee a pour quantité le nombre de graine plantées au tour précédant, il est initialisé à 5 en début de partie.
            return listePnj;
        }
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

        public static void SubirAttaque(Chats chat, Extraterrestre ET)
        {
            ET.VolerFaim(chat);
            ET.VolerEnergie(chat);
            ET.VolerDivertissement(chat);

            Console.WriteLine("Vous avez été attaqué ! Votre Chastronaute a perdu 1 point de Faim, 1 point d'Energie et 1 point de Divertissement ");
        }

        public static int SeFaireAttaquer(Chats chat, int compteurAttaque, ref int compteurAction, Carte carte, List<Chats> listeChats, ref bool estAttaque, ref bool seProtege)
        {
            if(compteurAttaque==0)
            {
                Random rnd = new Random();
                int intervention = rnd.Next(1, 6);
                if (intervention == 1)
                {
                    Extraterrestre ET = new Extraterrestre();
                    ET.AllerActivite(chat, chat.PositionChat);
                    AfficherCarte(carte, chat, listeChats, true);
                    Console.WriteLine("Vous êtes sur le point de vous faire attaquer par un extraterrestre, deux choix s'offrent à vous :\n 1 : Se protéger et perdre une action sur le tour\n 2 : Ne pas de se protéger et perdre 1 point dans chaque niveau de santé");//donc le joueur perdrait un point de NiveauFai, un point de NiveauDivertissement et un point de NiveauEnergie si il ne se protège pas.
                    estAttaque = true;
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
                            }
                            else
                            {
                                Console.WriteLine("Attention, vous devez rentrer une valeur entre 1 et 2 !");
                            }
                        }
                    } while (reponse < 1 && reponse > 2);
                    estAttaque = false;//on réinitialise estAttaque à la valeur false pour l'affiche de le carte de la prochaine action
                }                
            }
            return compteurAttaque;
        }

        public static Carte InitialiserCarte(List<Ressources> listeRessources, List<Batiments> listeBatiments, Chats chat)
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

        public static void AfficherCarte(Carte carte, Chats chat, List<Chats> ListeChats, bool estAttaque)// on utilise cette fonction plutôt que le ToString de Carte car cela permet un affichage avec des couleurs
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (i == chat.PositionChat[0] && j == chat.PositionChat[1])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(carte.Map[i, j]);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        if(estAttaque==true && i == chat.PositionChat[0]-1 && j == chat.PositionChat[1]-1)
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

        public static int FaireActionMetier(int numeroAction, Chats chat, Fonction fonction, List<Ressources> listeRessources, List<Batiments> listeBatiments, Carte map, ref int compteurAction, List<Chats> listeChats, List<PnJ> listePnj)
        //ajouter le fait qu'il puisse se faire attaquer par extraterrestre
        //rajouter test si list pnj vide
        {
            bool actionRealisee = true;
            if (numeroAction == 11 && chat.Fonction is Agriculteur) //Recolter
            {
                Agriculteur agriculteur = fonction as Agriculteur;
                agriculteur.AllerActivite(chat, listeBatiments[2]);
                agriculteur.Recolter(chat, listeRessources, true);
            }
            else
            {   if (numeroAction == 11)
                {
                    Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Récolter");
                    actionRealisee = false;
                }
                else
                {   if (numeroAction == 12 && chat.Fonction is Agriculteur) //Planter
                    {
                        Agriculteur agriculteur = fonction as Agriculteur;
                        agriculteur.AllerActivite(chat, listeBatiments[2]);//la place des batiments dans la liste dépends de la liste créer par InitialiserCarte()
                        listeRessources[8].Quantite = agriculteur.Planter(chat, listeRessources[7] as Graines, true);
                    }
                    else
                    {   if (numeroAction == 12)
                        {
                            Console.WriteLine("Attention ! Vous devez jouer en tant que chat agriculteur pour réaliser l'action Planter");
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
                                            Console.WriteLine("Attention vous devez entrer un nombre entre 1 et 2.");
                                        }
                                    }
                                } while (numRessourceCulturelle != 1 && numRessourceCulturelle != 2);                                
                            }
                            else
                            {   if (numeroAction == 21)
                                {
                                    Console.WriteLine("Attention ! Vous devez jouer en tant que chat artiste pour réaliser l'action Créer");
                                    actionRealisee = false;
                                }
                                else
                                {   if (numeroAction == 31 && chat.Fonction is Batisseur) //Construire
                                    {
                                        Console.WriteLine("Que voulez-vous construire ?  \n1 : Infirmerie (nécessite 1 bois et 1 pierre)\n2 : Poste (nécessite 1 bois et 1 pierre)\n3 : Potager (nécessite 2 bois)\n4 : Zone de pêche (nécessite 2 pierres)\n5 : Voir mes ressources");
                                        int numConstruction = 0;
                                        bool numConsCorrect = false;
                                        do
                                        {                                            
                                            numConstruction = int.Parse(Console.ReadLine()) + 6;// on ajoute 6 pour avoir le numéro entrée par le joueur correspondant au numéro du batiment recherché.
                                            if (numConstruction == 11)//5+6
                                            {
                                                Console.WriteLine(listeRessources[3] + "\n" + listeRessources[4]);
                                                Console.WriteLine("Que voulez-vous construire ?  \n1 : Infirmerie (nécessite 1 bois et 1 pierre)\n2 : Poste (nécessite 1 bois et 1 pierre)\n3 : Potager (nécessite 2 bois)\n4 : Zone de pêche (nécessite 2 pierres)");
                                                numConstruction = int.Parse(Console.ReadLine()) + 6;// on ajoute 6 pour avoir le numéro entrée par le joueur correspondant au numéro du batiment recherché.
                                                if (numConstruction >= 7 && numConstruction <= 10)
                                                {
                                                    numConsCorrect = true;
                                                }
                                            }
                                            else
                                            {
                                                if (numConstruction >= 7 && numConstruction <= 11)
                                                {
                                                    numConsCorrect = true;
                                                }
                                            }
                                            if(numConsCorrect==false)
                                            {
                                                Console.WriteLine("Attention le numéro entré est incorrect. Veuillez réessayer :");
                                            }
                                        } while (numConsCorrect == false);
                                        Batisseur batisseur = fonction as Batisseur;
                                        batisseur.Construire(numConstruction, map, chat, listeRessources, listeBatiments, listeChats, listePnj);
                                    }
                                    else
                                    {   if (numeroAction == 31)
                                        {
                                            Console.WriteLine("Attention ! Vous devez jouer en tant que chat Bâtisseur pour réaliser l'action Construire");
                                            actionRealisee = false;
                                        }
                                        else
                                        {   if (numeroAction == 32 && chat.Fonction is Batisseur) //Abattre un arbre
                                            {
                                                Batisseur batisseur = fonction as Batisseur;
                                                batisseur.AllerActivite(chat, listeBatiments[1]);
                                                batisseur.AbattreUnArbre(listeRessources, chat);
                                                Console.WriteLine("Vous venez d'abattre un arbre, cela vous à permis d'ajouter 2 planches de bois en plus dans vos ressoucres.");
                                                Console.WriteLine("Voici vos ressources actuelle de construction : {0} bois et {1} pierre(s)", listeRessources[3].Quantite, listeRessources[4].Quantite);
                                            }
                                            else
                                            {   if (numeroAction == 32)
                                                {
                                                    Console.WriteLine("Attention ! Vous devez jouer en tant que chat Bâtisseur pour réaliser l'action AbattreUnArbre");
                                                    actionRealisee = false;
                                                }
                                                else
                                                {   if (numeroAction == 33 && chat.Fonction is Batisseur) //Miner
                                                    {
                                                        Batisseur batisseur = fonction as Batisseur;
                                                        batisseur.AllerActivite(chat, listeBatiments[0]);
                                                        batisseur.Miner(listeRessources, chat);
                                                        Console.WriteLine("Vous venez de miner, cela vous a permis d'ajouter 2 unité de pierre en plus dans vos ressources.");
                                                        Console.WriteLine("Voici vos ressources actuelles de construction : {0} bois et {1} pierres", listeRessources[3].Quantite, listeRessources[4].Quantite);
                                                    }
                                                    else
                                                    {   if (numeroAction == 33)
                                                        {
                                                            Console.WriteLine("Attention ! Vous devez jouer en tant que chat Bâtisseur pour réaliser l'action Miner");
                                                            actionRealisee = false;
                                                        }
                                                        else
                                                        {   if (numeroAction == 41 && chat.Fonction is Patissier) //Faire un gateau (patisser)
                                                            {
                                                                Patissier patissier = fonction as Patissier;
                                                                patissier.AllerActivite(chat, listeBatiments[5]);
                                                                patissier.Patisser(listeRessources[1] as Gateaux, chat);
                                                                Console.WriteLine("Vous venez de faire 3 gâteaux, voici l'inventaire de vos ressources alimentaires : \n" + listeRessources[0] + listeRessources[1] + listeRessources[2]);
                                                            }
                                                            else
                                                            {   if (numeroAction == 41)
                                                                {
                                                                    Console.WriteLine("Attention ! Vous devez jouer en tant que chat Pâtissier pour réaliser l'action Patisser");
                                                                    actionRealisee = false;
                                                                }
                                                                else
                                                                {   if (numeroAction == 51 && chat.Fonction is Pecheur && map.Map[2,46] == " Zo") //Pecher
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
                                                                        Console.WriteLine("Vous avez pêché 5 poissons.\nVoici vos ressources alimentaires.");
                                                                        Console.WriteLine(listeRessources[0] + "" + listeRessources[1] + listeRessources[2]+ " ");
                                                                    }
                                                                    else
                                                                    {   if (numeroAction == 51)
                                                                        {
                                                                            Console.WriteLine("Attention ! Vous devez jouer en tant que chat Pêcheur pour réaliser l'action Pecher");
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

        public static int FaireActionBasique(int numeroAction, Chats chat, Fonction fonction, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<Chats> listeChats, Carte map, ref int compteurAction)
        {
            bool actionRealisee = true;
            if (numeroAction == 1) //Se nourrir
            {
                int numNourriture = 0;
                int quantiteNourriture = 0;
                do
                {
                    Console.WriteLine("Que voulez-vous que votre chat mange ? \n1 : Fruit (quantité : {0}) \n2 : Gateaux (quantité : {1}) \n3 : Poissons (quantité : {2}) ", listeRessources[0].Quantite, listeRessources[1].Quantite, listeRessources[2].Quantite);
                    numNourriture = int.Parse(Console.ReadLine()) - 1;
                    quantiteNourriture = listeRessources[numNourriture].Quantite;
                    chat.PositionChat = listeBatiments[3].PositionBatiment;
                    chat.Manger(listeRessources[numNourriture] as RessourceAlimentaire);
                    Console.WriteLine("\nVous venez de manger un {0}", listeRessources[numNourriture].Nom);
                    Console.WriteLine("\n{0} a à présent un niveau de faim de {1}", chat.Nom, chat.NiveauDeFaim);
                } while (quantiteNourriture == 0);
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
                            Console.WriteLine("Que voulez-vous utiliser comme ressource pour que votre chat se divertisse ? \n1 : Film \n2 : Livre");
                            numDivertissement = int.Parse(Console.ReadLine()) + 4;
                            if(numDivertissement != 5 && numDivertissement != 6)
                            {
                                Console.WriteLine("Vous devez entrer un nombre entre  1 et 2");
                            }
                        } while (numDivertissement != 5 && numDivertissement != 6);
                        chat.SeDivertir(listeRessources[numDivertissement] as RessourceCulturelle);
                        Console.WriteLine("\nVous venez de vous divertir avec un {0}", listeRessources[numDivertissement].Nom);
                        Console.WriteLine("\n{0} a à présent un niveau de divertissement  de {1}", chat.Nom, chat.NiveauDivertissement);
                    }
                    else
                    {
                        if (numeroAction == 4) //Changer le nom  d'un chat
                        {
                            Console.WriteLine("Voici la liste de vos chats :");
                            AfficherChats(listeChats);
                            int numChat = 0;
                            bool numeroCorrect = false;
                            do
                            {
                                Console.WriteLine("Quel nom voulez - vous changer ?");
                                numChat = int.Parse(Console.ReadLine()) - 1;
                                if(numChat>=0 && numChat<=listeChats.Count-1)
                                {
                                    numeroCorrect = true;
                                }
                                if(numeroCorrect==false)
                                {
                                    Console.WriteLine("Le numéro entré n'est pas correct veuillez réessayer.");
                                }
                            } while (numeroCorrect==false);
                            Console.WriteLine("Quel nom voulez-vous lui donner ?");
                            listeChats[numChat].Nom = Console.ReadLine();
                            Console.WriteLine("Votre chat {0} a bien été renommé {1}", listeChats[numChat].Fonction.Nom, listeChats[numChat].Nom);
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



        public static int FaireActionPnj(int numeroAction, Chats chat, Fonction fonction, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<PnJ> listePnj, Carte map, ref int compteurAction)
        {
            bool actionRealisee = true;
            if (numeroAction == 6 && map.Map[12, 18] == "Inf") //Se faire soigner
            {
                Guerisseur guerisseur = listePnj[0] as Guerisseur;
                guerisseur.AllerActivite(chat, new int[] { 12, 19 });
                guerisseur.Soigner(chat);
                Console.WriteLine("Vous venez d'aller voir le guérisseur, votre chat a donc un niveau d'énergie à 10.");
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
                        messager.AllerActivite(chat, new int[] { 8, 19 });
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

        public static int ProposerAction(Chats chat, Carte map, List<Ressources> listeRessources, List<Batiments> listeBatiments, List<Chats> listeChats, List<PnJ> listePnj, ref int compteurAction, int compteurAttaque, ref bool estAttaque, ref bool seProtege)
        {
            //Affichage de la liste des actions 
            Console.WriteLine("Vous pouvez choisir une action à effectuer parmi la liste suivante : \n");
            List<string> listeActionPossible = new List<string> { " 1 : Se nourrir" , " 2 : Se reposer" , " 3 : Se divertir" , " 4 : Changer le nom d'un chat" , " 5 : Afficher les différents niveaux d'un chat" , " 6 : Récolter (propre au chat Agriculteur)" , " 7 : Planter (propre au chat Agriculteur)", " 8 : Construire (propre au chat Batisseur)", " 9 : Abattre un arbre (propre au chat Batisseur)", " 10 : Miner (propre au chat Batisseur)", " 11 : Patisser (propre au chat Patissier)", " 12 : Créer un divertissement (propre au chat Artiste)" };
            if (map.Map[2, 46] == " Zo")
            {
                listeActionPossible.Add(" 13 : Pecher");
            }
            if (map.Map[12, 18] == "Inf")
            {
                listeActionPossible.Add(" 14 : Aller voir le guérisseur ");
            }
            if(map.Map[8, 18] == "  Po")
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
                //boucle pour choisir le "FaireAction"

                if (numeroAction >= 1 && numeroAction <= 5)
                {
                    if(numeroAction!=4 && numeroAction!=5)
                    {
                        compteurAttaque = SeFaireAttaquer(chat, compteurAttaque, ref compteurAction, map, listeChats, ref estAttaque, ref seProtege);
                    }
                    chat.AfficherNiveaux();
                    FaireActionBasique(numeroAction, chat, chat.Fonction, listeRessources, listeBatiments, listeChats, map, ref compteurAction);
                    chat.AfficherNiveaux();
                    /*Console.WriteLine(compteurAction);*/
                    Console.WriteLine(compteurAttaque);
                }
                else
                {
                    if ((numeroAction >= 11 && numeroAction <= 12) || (numeroAction >= 31 && numeroAction <= 33) || numeroAction==41 || numeroAction==21 || numeroAction == 51)
                    {
                        compteurAttaque = SeFaireAttaquer(chat, compteurAttaque, ref compteurAction, map, listeChats, ref estAttaque, ref seProtege);
                        chat.AfficherNiveaux();
                        FaireActionMetier(numeroAction, chat, chat.Fonction, listeRessources, listeBatiments, map, ref compteurAction, listeChats, listePnj);
                        chat.AfficherNiveaux();
                        Console.WriteLine(compteurAction);
                        Console.WriteLine(compteurAttaque);
                    }
                    else
                    {
                        if (numeroAction >= 6 && numeroAction <= 7)
                        {
                            compteurAttaque = SeFaireAttaquer(chat, compteurAttaque, ref compteurAction, map, listeChats, ref estAttaque, ref seProtege);
                            chat.AfficherNiveaux();
                            FaireActionPnj(numeroAction, chat, chat.Fonction, listeRessources, listeBatiments, listePnj, map, ref compteurAction);
                            chat.AfficherNiveaux();
                            Console.WriteLine(compteurAction);
                            Console.WriteLine(compteurAttaque);
                        }
                        else
                            Console.WriteLine("Attention, vous devez choisir un numéro d'action existant");
                    }
                }
                //Regarder comment faire pour relancer la proposition
            }while (actionRealisable==false); //boucle do...while pour redemander au joueur de choisir une action à faire tant que le numéro d'action saisi n'est pas correct           
            return compteurAttaque;
        }
    }
}





