using CS_Freecell;
using static CS_Freecell.Carte;

namespace TestFreecell
{
    [TestClass]
    public class UnitTestCaseLibre
    {
        [TestMethod]
        public void TestDuConstructeur()
        {
            CaseLibre pile = new();
            Console.WriteLine(pile.ToString());
            Assert.AreEqual(pile.Nom, "V", "Le nom de la case devrait être V");
        }

        [TestMethod]
        public void TestPeutDéposer()
        {
            CaseLibre caseLibre = new();
            Carte carte = new(1, Enseigne.PIQUE, true);

            Assert.IsTrue(caseLibre.PeutDéposer(carte), "La méthode PeutDéposer doit retourner true");
            caseLibre.Déposer(carte);

            Carte carte1 = new(1, Enseigne.PIQUE, true);
            caseLibre.Déposer(carte1);

            Carte carte2 = new(3, Enseigne.PIQUE, true);

            Assert.IsFalse(caseLibre.PeutDéposer(carte2));
        }
    }
}
