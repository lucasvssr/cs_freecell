using CS_Freecell;
using static CS_Freecell.Pile;
using static CS_Freecell.Carte;


namespace TestFreecell
{
    [TestClass]
    public class UnitTestPile
    {
        private class TestPile : Pile
        {
            public override string Nom { get; set; }
            public override int Numéro { get; set; }

            public override bool PeutDéposer(Carte c)
            {
                return true;
            }
        }

        bool ThrowException = false;
        Carte carte1 = new(1, Enseigne.TREFLE, true);
        Carte carte2 = new(1, Enseigne.PIQUE, true);
        Carte carte3 = new(1, Enseigne.CARREAU, true);
        Carte carte4 = new(1, Enseigne.COEUR, true);
        TestPile pile1 = new TestPile();

        [TestMethod]
        public void TestRetirer()
        {
            try
            {
                pile1.Retirer();
            }
            catch (InvalidOperationException)
            {
                ThrowException = true;
            }
            Assert.IsTrue(ThrowException, "La pile est vide");
        }

        [TestMethod]
        public void TestDéposer()
        {
            pile1.Déposer(carte4);
            Assert.AreEqual(pile1.Dernière, carte4, "La carte a été ajouté");
        }

        [TestMethod]
        public void TestPeutRetirer()
        {
            pile1.Déposer(carte4);
            Assert.AreEqual(pile1.PeutRetirer(), true, "La carte peut être retiré");
        }

        [TestMethod]
        public void TestRetirerCarte()
        {
            pile1.Déposer(carte3);
            pile1.Déposer(carte2);
            Assert.AreEqual(pile1.Retirer(), carte2, "La carte retiré à bien été renvoyé");
        }

        [TestMethod]
        public void TestCount()
        {
            pile1.Déposer(carte4);
            pile1.Déposer(carte3);
            Assert.AreEqual(pile1.Count, 2, "Il y a le bon nombre de carte");
        }

        [TestMethod]
        public void TestEffacer()
        {
            pile1.Effacer();
            Assert.IsTrue(pile1.EstVide, "la pile est vide");
        }
    }
}