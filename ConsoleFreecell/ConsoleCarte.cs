 using CS_Freecell;

namespace ConsoleFreecell
{
    public class ConsoleCarte
    {
        private const char left_up_corner = '\u250C';
        private const char horiz_corner = '\u2500';
        private const char right_up_corner = '\u2510';
        private const char vert_corner = '\u2502';
        private const char left_dwn_corner = '\u2514';
        private const char right_dwn_corner = '\u2518';
        private const char left_up_corner2 = '\u2554';
        private const char horiz_corner2 = '\u2550';
        private const char right_up_corner2 = '\u2557';
        private const char vert_corner2 = '\u2551';
        private const char left_dwn_corner2 = '\u255A';
        private const char right_dwn_corner2 = '\u255D';
        private const char _background = '\u2592';
        private const char _trefle = '\u2663';
        private const char _coeur = '\u2665';
        private const char _carre = '\u2666';
        private const char _pique = '\u2660';
        public const int LARGEUR = 5;
        public const int HAUTEUR = 5;
        private const ConsoleColor _backgroundColor = ConsoleColor.DarkGreen;
        private const ConsoleColor _foregroundColor = ConsoleColor.Black;

        private CaseCaractère?[,] _écran;

        public int NbLignes { get => _écran.GetLength(0); }
        public int NbColonnes { get => _écran.GetLength(1); }

        public ConsoleCarte(int Lignes = -1, int Colonnes = -1)
        {
            if ((Lignes == -1) || (Lignes > Console.WindowHeight))
            {
                Lignes = Console.LargestWindowHeight;
            }
            if ((Colonnes == -1) || (Colonnes > Console.WindowWidth))
            {
                Colonnes = Console.LargestWindowWidth;
            }
            _écran = new CaseCaractère[Lignes, Colonnes];
            Console.SetWindowSize(Colonnes, Lignes);
        }

        private CaseCaractère? this[int li, int co]
        {
            get
            {
                if ((li >= 0 && li < _écran.GetLength(0)) && (co >= 0 && co < _écran.GetLength(1))) ;
                {
                    return _écran[li, co];
                }
            }
            set
            {
                if ((li >= 0 && li < _écran.GetLength(0)) && (co >= 0 && co < _écran.GetLength(1))) ;
                {
                    _écran[li,co] = value;
                }
            }
        }

        public class CaseCaractère
        {
            public ConsoleColor Couleur { get; set; }
            public ConsoleColor CouleurDeFond { get; set; }
            public char Caractère { get; set; }
        }

        public void Afficher(string s, int column, int li, ConsoleColor fg = _foregroundColor, ConsoleColor bg = _backgroundColor)
        {
            for (int i = 0, co = column; i < s.Length && co < _écran.GetLength(1); ++i, ++co)
            {
                this[li, co] = new CaseCaractère
                {
                    Caractère = s[i],
                    CouleurDeFond = bg,
                    Couleur = fg
                };
            }
        }
        public void Afficher(Carte? c, int column, int line)
        {
            int li = line;
            int co = column;
            if (c is null)
            {
                ConsoleColor bg = _backgroundColor;
                ConsoleColor fg = _foregroundColor;
                int i;
                // Première ligne
                this[li, co] = new CaseCaractère
                {
                    Caractère = left_up_corner,
                    Couleur = fg,
                    CouleurDeFond = bg
                };
                for (i = 1; i <= 3; ++i)
                    this[li, co + i] = new CaseCaractère
                    {
                        Caractère = horiz_corner,
                        Couleur = fg,
                        CouleurDeFond = bg
                    };
                this[li, co + 4] = new CaseCaractère
                {
                    Caractère = right_up_corner,
                    Couleur = fg,
                    CouleurDeFond = bg
                };
                // Trois lignes suivantes
                int j;
                for (i = 1; i <= 3; ++i)
                {
                    for (j = 0; j < 5; ++j)
                    {
                        this[li + i, co + j] = new CaseCaractère
                        {
                            Caractère = j == 0 || j == 4 ?
                            vert_corner : ' ',
                            Couleur = fg,
                            CouleurDeFond = bg
                        };
                    }
                }
                char car;
                for (i = 0; i <= 4; ++i)
                {
                    if (i == 0) car = left_dwn_corner;
                    else if (i == 4) car = right_dwn_corner;
                    else car = horiz_corner;
                    this[li + 4, co + i] = new CaseCaractère
                    {
                        Caractère = car,
                        Couleur = fg,
                        CouleurDeFond = bg
                    };
                }
            }
            else
            {
                ConsoleColor forecolor = ConsoleColor.Cyan;
                ConsoleColor bg = ConsoleColor.Black;
                char color = ' ';
                switch (c.Couleur)
                {
                    case Carte.Enseigne.PIQUE:
                        color = _pique;
                        break;
                    case Carte.Enseigne.TREFLE:
                        color = _trefle;
                        break;
                    case Carte.Enseigne.COEUR:
                        color = _coeur;
                        forecolor = ConsoleColor.Red;
                        break;
                    default:
                        color = _carre;
                        forecolor = ConsoleColor.Red;
                        break;
                }
                string face = c.Face.ToString();
                string lface = face + " ";
                string rface = " " + face;
                if (c.Face.Valeur == 10)
                    lface = rface = face;
                if (!c.Visible) forecolor = ConsoleColor.White;
                char[] car = new char[5];
                for (int i = 0; i <= 4; ++i)
                {
                    if (i == 0)
                    {
                        car[0] = left_up_corner2;
                        car[1] = car[2] = car[3] = horiz_corner2;
                        car[4] = right_up_corner2;
                    }
                    else if (i == 4)
                    {
                        car[0] = left_dwn_corner2;
                        car[4] = right_dwn_corner2;
                        car[1] = car[2] = car[3] = horiz_corner2;
                    }
                    else
                    {
                        car[0] = car[4] = vert_corner2;
                        if (c.Visible)
                        {
                            switch (i)
                            {
                                case 1:
                                    car[1] = lface[0];
                                    car[2] = lface[1];
                                    car[3] = color;
                                    break;
                                case 2:
                                    car[1] = car[3] = ' ';
                                    car[2] = color;
                                    break;
                                case 3:
                                    car[1] = color;
                                    car[2] = rface[0]; car[3] = rface[1];
                                    break;
                            }
                        }
                        else
                        {
                            car[1] = car[2] = car[3] = _background;
                        }
                    }
                    for (int j = 0; j <= 4; ++j)
                    {
                        this[li + i, co + j] = new CaseCaractère
                        {
                            Caractère = car[j],
                            Couleur = forecolor,
                            CouleurDeFond = bg
                        };
                    }
                }
            }
        }
        public int DernièreLigne()
        {
            int li = _écran.GetLength(0) - 1;
            bool empty = true;
            while (li > 0 && empty)
            {
                int co = 0;
                while (co < _écran.GetLength(1) && _écran[li, co] is null)
                    ++co;
                empty = co == _écran.GetLength(1);
                if (empty)
                {
                    --li;
                }
            }
            return li;
        }
        public void Rafraichir()
        {
            Console.Clear();
            ConsoleColor bg_previous = Console.BackgroundColor;
            ConsoleColor previous = Console.ForegroundColor;
            int lastLine = DernièreLigne();
            // Affichage de l'écran !
            for (int li = 0; li <= lastLine; ++li)
            {
                ConsoleColor color = _écran[li, 0] is null ? _foregroundColor : _écran[li, 0].Couleur;
                ConsoleColor bg_color = _écran[li, 0] is null ? _backgroundColor : _écran[li, 0].CouleurDeFond;
                string s = "";
                for (int co = 0; co < _écran.GetLength(1); ++co)
                {
                    if (_écran[li, co] is null)
                    {
                        _écran[li, co] = new CaseCaractère
                        {
                            Caractère = ' ',
                            Couleur = color,
                            CouleurDeFond = _backgroundColor
                        };
                    }
                    if (_écran[li, co].Couleur == color && _écran[li, co].CouleurDeFond == bg_color)
                    {
                        s += _écran[li, co].Caractère;
                    }
                    else
                    {
                        if (s.Length > 0)
                        {
                            Console.ForegroundColor = color;
                            Console.BackgroundColor = bg_color;
                            Console.Write(s);
                        }
                        color = _écran[li, co].Couleur;
                        bg_color = _écran[li, co].CouleurDeFond;
                        s = _écran[li, co].Caractère.ToString();
                    }
                }
                Console.ForegroundColor = color;
                Console.BackgroundColor = bg_color;
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.ForegroundColor = previous;
            Console.BackgroundColor = bg_previous;
        }

        public void Effacer()
        {
            for (int i= 0 ;i< _écran.GetLength(0) ;i++)
            {
                for (int j= 0; j < _écran.GetLength(1); j++)
                {
                    _écran[i, j] = null;
                }
            }
        }

        public void Afficher(Pile pile, int column, int line) 
        {
            Afficher(pile.Dernière, column, line);
        }

        public void Afficher(Colonne pile, int column, int line)
        {
            foreach (Carte c in pile)
            {
                line = line + 2;
                Afficher(c, column, line);
            }
        }
        
        public void Afficher(Freecell freecell)
        {
            int column = 0;
            foreach (PileDeBase col in freecell.PilesDeBase)
            {
                Afficher(col, column, 0);
                column += 5;
            }

            column += 5;
            foreach (CaseLibre col in freecell.CaseLibres)
            {
                Afficher(col, column, 0);
                column += 5;
            }

            int columnCol = 0;
            foreach (Colonne col in freecell.Colonnes)
            {
                Afficher(col, columnCol, 4);
                columnCol +=5;
            }
        }
    }
}