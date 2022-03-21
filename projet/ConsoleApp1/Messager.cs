using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Messager : PnJ
    {
        public Messager() : base("Messager", 1)
        { }

        public override void AllerActivite(Chats chat, Batiments lieu)
        {
            chat.PositionChat = lieu.PositionBatiment;
        }

        public void Livrer(Livres livre, Films film, Fruits fruit, Poissons poisson, Graines graine, Pierres pierre, Bois bois)
        {
            Random rnd = new Random();
            int numero=rnd.Next(1,6);
            int nombreDeResources = rnd.Next(1, 10);
            if(numero==1)
            {
                film.Quantite += nombreDeResources;
            }
            else
            {
                if (numero == 2)
                {
                    livre.Quantite += nombreDeResources;
                }
                else
                {
                    if (numero == 3)
                    {
                        poisson.Quantite += nombreDeResources;
                    }
                    else
                    {
                        if (numero == 4)
                        {
                            fruit.Quantite += nombreDeResources;
                        }
                        else
                        {
                            if (numero == 5)
                            {
                                graine.Quantite += nombreDeResources;
                            }
                            else
                            {
                                if (numero == 6)
                                {
                                    pierre.Quantite += nombreDeResources;
                                }
                                else
                                {
                                    bois.Quantite += nombreDeResources;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
