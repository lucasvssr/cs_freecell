using CS_Freecell;
using static CS_Freecell.Carte;

namespace TestFreecell
{
    [TestClass]
    public class UnitTestPileDeBase
    {
        [TestMethod]
        public void TestDuConstructeur()
        {
            PileDeBase pile = new();
            Assert.AreEqual(pile.Nom, "B", "Le nom de la case devrait être B");
        }

        [TestMethod]
        public void TestPeutDéposer()
        {
            PileDeBase pile = new();
            Carte carte = new(1, Enseigne.PIQUE, true);
            Assert.AreEqual(pile.PeutDéposer(carte), true, "La méthode PeutDéposer doit retourner true");
            
            Carte carte1 = new(1, Enseigne.PIQUE, true);
            pile.Déposer(carte);

            Carte carte2 = new(2, Enseigne.PIQUE, true);
            Assert.AreEqual(pile.PeutDéposer(carte2), true, "La méthode PeutDéposer doit retourner true");

            Carte carte3 = new(3, Enseigne.CARREAU, true);
            Assert.AreEqual(pile.PeutDéposer(carte3), false, "La méthode PeutDéposer doit retourner false");
        }
    }
}