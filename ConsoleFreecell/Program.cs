using CS_Freecell;
using ConsoleFreecell;

/*
ConsoleCarte plateau = new(40, 100);
Carte c = new(1, Carte.Enseigne.TREFLE, true);
Carte c1 = new(5, Carte.Enseigne.TREFLE, true);
Carte c2 = new(7, Carte.Enseigne.TREFLE, true);
Carte c3 = new(1, Carte.Enseigne.TREFLE, true);
Carte c4 = new(11, Carte.Enseigne.TREFLE, true);

plateau.Afficher(c, 0, 0);
plateau.Afficher(c1, 5, 1);
plateau.Afficher(c2, 10, 1);
plateau.Afficher(c3, 15, 0);
plateau.Afficher(c4, 20, 1);

plateau.Effacer();
//plateau.Afficher(c3, 15, 0);
//plateau.Afficher(c4, 0, 0);
plateau.Rafraichir();

Colonne colonne = new();
colonne.Déposer(c);
colonne.Déposer(c2);
colonne.Déposer(c4);
//plateau.Afficher(colonne, 10, 0);
plateau.Rafraichir();


Freecell freecell = new Freecell();
freecell.Distribuer();
plateau.Afficher(freecell);
plateau.Rafraichir();
*/

Freecell freecell = new Freecell();
freecell.Distribuer();
ConsoleCarte plateau = new(60, 100);

bool stop = false;

do
{
    plateau.Effacer();
    plateau.Afficher(freecell);
    plateau.Rafraichir();

    Console.WriteLine("Entrez un déplacement ou 'STOP' pour arrêter.");
    string reponse = Console.ReadLine().ToUpper();

    if (reponse != null && reponse[0] != 'S')
    {
        Déplacement déplacement = new(reponse);
        freecell.Appliquer(déplacement);
    }
    else
    {
        stop = true;
    }
}
while (!stop);

plateau.Effacer();
plateau.Afficher(freecell);
plateau.Rafraichir();
