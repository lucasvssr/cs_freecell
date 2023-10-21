using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Freecell
{
    public class Freecell
    {
        private CaseLibre[] _casesLibre;
        private PileDeBase[] _pilesDeBase;
        private Colonne[] _colonnes;

        public CaseLibre[] CaseLibres { get { return _casesLibre; } }
        public PileDeBase[] PilesDeBase { get => _pilesDeBase; }
        public Colonne[] Colonnes => _colonnes;

        public Freecell()
        {
            _casesLibre = new CaseLibre[4];
            _pilesDeBase = new PileDeBase[4];
            _colonnes = new Colonne[8];
            
            for (int x = 0; x < _casesLibre.Length; x++)
            {
                CaseLibre ca = new();
                ca.Numéro = x+1;
                _casesLibre[x] = ca;
            }

            for (int y = 0; y < _pilesDeBase.Length; y++)
            {
                PileDeBase pi = new();
                pi.Numéro = y + 1;
                _pilesDeBase[y] = pi;
            }

            for (int z = 0; z < _colonnes.Length; z++)
            {
                Colonne co = new();
                co.Numéro = z+1;
                _colonnes[z] = co;
            }
        }

        public void Distribuer()
        {
            Array.ForEach(CaseLibres, (l) => { if (l != null) { l.Effacer(); } });
            Array.ForEach(PilesDeBase, (p) => { if (p != null) { p.Effacer(); } });
            Array.ForEach(Colonnes, (c) => { if (c != null) { c.Effacer(); } });

            List<Carte> jeu = new List<Carte>(52);

            foreach (Carte.Enseigne a in Enum.GetValues(typeof(Carte.Enseigne)))
            {
                for (int i = 1; i <= 13; i++)
                {
                    jeu.Add(new Carte(i, a, true));
                }
            }

            Random rnd= new Random();

            while (jeu.Count > 0)
            {
                foreach (Colonne c in _colonnes)
                {
                    if (jeu.Count != 0)
                    {
                        int i = rnd.Next(jeu.Count);
                        c.Déposer(jeu[i]);
                        jeu.RemoveAt(i);
                    }
                }
            }
        }

        public Pile? RécupérerPile(Déplacement.Pile pile)
        {
            if (pile.Nom == Déplacement.NomPile.COLONNE)
            {
                for(int x = 0; x < Colonnes.Length; x++)
                {
                    if (x == pile.Numéro)
                    {
                        return Colonnes[x];
                    }
                }
            }

            if(pile.Nom == Déplacement.NomPile.CASE_LIBRE)
            {
                for(int y = 0; y < CaseLibres.Length; y++)
                {
                    if(y == pile.Numéro)
                    {
                        return CaseLibres[y];
                    }
                }
            }

            if(pile.Nom == Déplacement.NomPile.PILE_DE_BASE)
            {
                return null;
            }

            throw new ArgumentException(String.Format("Le numéro de pile {0} n’existe pas pour la pile {1}", pile.Numéro, pile.Nom));
        }

        public Pile? GetBaseAcceptant(Carte carte)
        {
            foreach(PileDeBase pile in PilesDeBase)
            {
                if (pile.EstVide)
                {
                    return pile;
                }
                if (carte.PeutCouvrir(pile.Dernière))
                {
                    return pile;
                }
            }
            return null;
        }

        public void Appliquer(Déplacement déplacement)
        {
            Pile depuis = RécupérerPile(déplacement.Depuis);

            if (depuis == null)
            {
                throw new ArgumentException("On ne peut pas retirer une carte des piles de base");
            }
            if (!depuis.PeutRetirer())
            {
                throw new ArgumentException(String.Format("Le déplacement depuis la pile {0} ne peut pas se faire.", depuis.Nom));
            }

            Carte carte = depuis.Retirer();

            Pile vers = RécupérerPile(déplacement.Vers);

            if (vers == null)
            {
                if (this.GetBaseAcceptant(carte) == null)
                {
                    throw new ArgumentException(String.Format("Le déplacement depuis la pile {0} vers la base ne peut pas se faire", vers.Nom));
                }
                vers.Numéro++;
            }
            else
            {
                if (vers.PeutDéposer(carte) == false)
                {
                    throw new ArgumentException(String.Format("Le déplacement depuis la pile {0} vers la pile {1} ne peut pas se faire", depuis.Nom, vers.Nom));
                }
            }

            vers.Déposer(carte);
        }
    }
}
