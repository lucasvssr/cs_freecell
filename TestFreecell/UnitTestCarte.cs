using CS_Freecell;
using static CS_Freecell.Carte;

namespace TestFreecell
{
    [TestClass]
    public class UnitTestCarte
    {
        [TestMethod]
        public void TestConstructeurFigure()
        {
            bool ThrowException = false;
            try
            {
                for (int i = 2; i < 11; i++)
                {
                    Figure figure = new Figure(i);
                    Assert.AreEqual(figure.ToString(), i.ToString());
                }
            }
            catch (ArgumentException)
            {
                ThrowException = true;
            }

            Assert.IsFalse(ThrowException, "La construction de Figure doit accépter les valeurs entre 1 et 10");

            string[] lettre = { "A", "V", "D", "R" };
            int[] position = { 0, 10, 11, 12 };

            try
            {
                for (int i = 0; i  < lettre.Length; i++)
                {
                    Figure figure = new Figure(lettre[i]);
                    Assert.AreEqual(figure.Valeur.ToString(), (position[i]+1).ToString());
                }
            }
            catch (ArgumentException)
            {
                ThrowException = true;
            }

            Assert.IsFalse(ThrowException, "La construction de Figure doit accépter les valeurs A, V, D, R");
        }

        [TestMethod]
        public void TestConstructeurFigureAvecException()
        {
            bool ThrowException = false;

            try
            {
                for (int i = 11; i < 20; i++)
                {
                    Figure figure = new Figure(i);
                }
            }
            catch (ArgumentException)
            {
                ThrowException = true;
            }

            Assert.IsTrue(ThrowException, "La construction de Figure doit accépter les valeurs entre 1 et 10");

            string[] lettre = { "H", "G", "Z", "T" };
            int[] position = { 0, 10, 11, 12 };

            try
            {
                for (int i = 0; i < lettre.Length; i++)
                {
                    Figure figure = new Figure(lettre[i]);
                }
            }
            catch (ArgumentException)
            {
                ThrowException = true;
            }

            Assert.IsTrue(ThrowException, "La construction de Figure doit accépter les valeurs A, V, D, R");

        }

        [TestMethod]
        public void TestRougeNoir()
        {
            Carte carte1 = new (1, Enseigne.TREFLE, true);
            Assert.AreEqual(carte1.Noire , true, "La carte devrait être Rouge");

            Carte carte2 = new(1, Enseigne.PIQUE, true);
            Assert.AreEqual(carte2.Noire, true, "La carte devrait être Rouge");

            Carte carte3 = new(1, Enseigne.CARREAU, true);
            Assert.AreEqual(carte3.Noire, false, "La carte devrait être Noire");

            Carte carte4 = new(1, Enseigne.COEUR, true);
            Assert.AreEqual(carte4.Noire, false, "La carte devrait être Noire");
        }

        [TestMethod]
        public void TestPeutCouvrir()
        {
            Carte c1 = new Carte(8, Enseigne.PIQUE, true);
            Carte c2 = new Carte(7, Enseigne.CARREAU, true);

            Assert.IsTrue(c2.PeutCouvrir(c1), "La carte devrait être couverte");
        }
    }
}