using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Freecell
{
    public class Déplacement
    {
        public class Pile
        {
            public NomPile Nom { get; set; }
            public int Numéro { get; set; }

            public Pile(NomPile nom, int numéro = -1)
            {
                Nom = nom;
                Numéro = numéro;
            }
        }

        public enum NomPile
        {
            COLONNE,
            CASE_LIBRE,
            PILE_DE_BASE
        }

        public Déplacement.Pile Depuis;
        public Déplacement.Pile Vers;

        public int DécoderNuméro(string caractere)
        {
            foreach (char c in caractere)
            {
                if (0 <= c || c <= 9)
                {
                    return (int)Char.GetNumericValue(c);
                }
            }
            throw new ArgumentException(String.Format("Impossible de lire un numéro dans '{0}'",caractere));
        }

        public Déplacement.Pile Décoder(string caractere)
        {
            for (int i = 0; i < caractere.Length; i++)
            {
                if (caractere[i] == 'B')
                {
                    return new Pile(NomPile.PILE_DE_BASE);
                }
                if (caractere[i] == 'V')
                {
                    return new Pile(NomPile.CASE_LIBRE, DécoderNuméro(caractere[i+1].ToString()));
                }
                if (caractere[i] == 'C')
                {
                    return new Pile(NomPile.COLONNE, DécoderNuméro(caractere[i+1].ToString()));
                }
            }
            throw new ArgumentException(String.Format("Aucune pile n'est  reconnue dans '{0}'", caractere));
        }

        public Déplacement(string piles)
        {
            char[] chars = piles.ToCharArray();
            string depuis = "";
            string vers = ""; ;
            bool e = false;
            foreach(char c in chars)
            {
                if (e == false)
                {
                    if (c != ' ')
                    {
                        if (c == 'C' || c == 'V' || c == 'B' || (c == (int)c))
                        {
                            depuis += c;
                        }
                    }
                    if(c == ' ')
                    {
                        e = true;
                    }
                }
                else
                {
                    if (c != ' ')
                    {
                        if (c == 'C' || c == 'V' || c == 'B' || (c == (int)c))
                        {
                            vers += c;
                        }
                    }
                }
            }

            Depuis = Décoder(depuis);
            Vers = Décoder(vers);

            if (Depuis == null || Vers == null)
            {
                throw new ArgumentException(String.Format("Déplacement non reconnue dans '{0}'", piles));
            }
        }
    }
}
