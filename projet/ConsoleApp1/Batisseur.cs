using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Batisseur : Metier
    {
        public Batisseur() : base("Bâtisseur", 3)
        { }

        public override void AllerActivite(Chats chat, Batiments lieu)
        {
            chat.PositionChat = lieu.PositionBatiment;
        }

        public void Construire(int numeroBatiment, Carte map)
        {
            if (numeroBatiment == 7)
            {
                Infirmerie infirmerie = new Infirmerie();
                infirmerie.Construire(map);
            }
            else
            {
                if (numeroBatiment == 8)
                {
                    Poste poste = new Poste();
                    poste.Construire(map);
                }
                else
                {
                    if (numeroBatiment == 9)
                    {
                        Potager potager = new Potager();
                        potager.Construire(map);
                    }
                    else
                    {
                        if (numeroBatiment == 10)
                        {
                            ZoneDePeche zoneDePeche = new ZoneDePeche();
                            zoneDePeche.Construire(map);
                        }

                    }
                }
            }
        }

        public void AbattreUnArbre(Bois bois)
        {
            bois.Quantite += 3;
        }


        public void Miner(Pierres pierre)
        {
            pierre.Quantite += 3;
        }

    }
}
