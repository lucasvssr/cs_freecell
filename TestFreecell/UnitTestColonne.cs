using CS_Freecell;
using static CS_Freecell.Carte;

namespace TestFreecell
{
    [TestClass]
    public class UnitTestColonne
    {
        [TestMethod]
        public void TestDuConstructeur()
        {
            Colonne colonne = new();
            Assert.AreEqual(colonne.Nom, "C", "Le nom de la case devrait être C");
        }

        [TestMethod]
        public void TestPeutDéposer()
        {
            Colonne colonne = new();
            Carte carte = new(1, Enseigne.PIQUE, true);

            Assert.IsTrue(colonne.PeutDéposer(carte), "La méthode doit retourner true");
            colonne.Déposer(carte);

            Carte carte1 = new(2, Enseigne.COEUR, true);

            Assert.IsTrue(colonne.PeutDéposer(carte1), "La méthode doit retourner true");
            
        }
    }
}
