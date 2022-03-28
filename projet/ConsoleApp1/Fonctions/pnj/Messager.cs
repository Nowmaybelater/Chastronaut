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

        public void Livrer(List<Ressources> ListeRessources, Chats chat)
        {
            Random rnd = new Random();
            int numero=rnd.Next(1,8);
            int nombreDeResources = rnd.Next(1, 10);
            if(numero==1)
            {
                ListeRessources[0].Quantite += nombreDeResources;
            }
            else
            {
                if (numero == 2)
                {
                    ListeRessources[1].Quantite += nombreDeResources;
                }
                else
                {
                    if (numero == 3)
                    {
                        ListeRessources[2].Quantite += nombreDeResources;
                    }
                    else
                    {
                        if (numero == 4)
                        {
                            ListeRessources[3].Quantite += nombreDeResources;
                        }
                        else
                        {
                            if (numero == 5)
                            {
                                ListeRessources[4].Quantite += nombreDeResources;
                            }
                            else
                            {
                                if (numero == 6)
                                {
                                    ListeRessources[5].Quantite += nombreDeResources;
                                }
                                else
                                {
                                    if (numero == 7)
                                    {
                                        ListeRessources[6].Quantite += nombreDeResources;
                                    }
                                    else
                                    {
                                        ListeRessources[6].Quantite += nombreDeResources;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            chat.NiveauDeFaim -= 1;
            chat.NiveauDivertissement -= 1;
            chat.NiveauEnergie -= 1;
        }
    }
}
