namespace CS_Freecell
{
    public class Carte
    {
        public class Figure
        {
            public List<string> valeursAcceptés = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "V", "D", "R" };

            public int Valeur { get; }

            public Figure(int valeur)
            {
                if (valeur < 1 || valeur > 14)
                {
                    throw new ArgumentException(String.Format("La valeur {0} n’est pas acceptée pour une figure", valeur));
                }

                Valeur = valeur;
            }

            public Figure(string valeur)
            {
                if (!valeursAcceptés.Contains(valeur))
                {
                    throw new ArgumentException(String.Format("La valeur {0} n’est pas acceptée pour une figure", valeur));
                }

                int x = 0;
                foreach (string v in valeursAcceptés)
                {
                    if (v == valeur)
                    {
                        Valeur = x+1;
                    }
                    x++;
                }
            }

            public override bool Equals(object? obj)
            {
                return (obj is Figure fig) && (fig.Valeur == Valeur);
            }

            public override int GetHashCode()
            {
                return Valeur;
            }

            public override string ToString()
            {
                return valeursAcceptés[Valeur-1].ToString();
            }
        }
        public enum Enseigne : byte
        {
            TREFLE = 1, 
            PIQUE, 
            COEUR, 
            CARREAU
        }

        public Figure Face { get; }
        public Enseigne Couleur { get; }
        public bool Visible { get; set; }

        public bool Noire = false;

        public Carte(Figure figure, Enseigne couleur, bool visible)
        {
            Face = figure;
            Couleur = couleur;
            Visible = visible;
            if (Couleur == Enseigne.TREFLE || Couleur == Enseigne.PIQUE)
            {
                Noire = true;
            }
        }

        public Carte(int figure, Enseigne couleur, bool visible)
        {
            Face = new Figure(figure);
            Couleur = couleur;
            Visible = visible;
            if (Couleur == Enseigne.TREFLE || Couleur == Enseigne.PIQUE)
            {
                Noire = true;
            }
        }

        public override string ToString()
        {
            return "Face : " + Face + ", Couleur : " + Couleur + ", Visible : " + Visible;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Carte))
            {
                return false;
            }

            Carte carte = (Carte)obj;

            return Face == carte.Face && Couleur == carte.Couleur && Visible == carte.Visible;
        }

        public override int GetHashCode()
        {
            return 4*((Face.Valeur - 1) * 4 + ((int)Couleur));
        }

        public bool PeutCouvrir(Carte carte)
        {
            if((this.Face.Valeur+1 == carte.Face.Valeur) && (this.Couleur != carte.Couleur))
            {
                return true;
            }
            return false;
        }
    }
}