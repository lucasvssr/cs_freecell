using CS_Freecell;

namespace TestFreecell
{
    [TestClass]
    public class UnitTestFreecell
    {
        [TestMethod]
        public void TestRécupérerPile()
        {
            Déplacement deplacement = new("B C2");
            Assert.AreEqual(deplacement.Depuis.Nom, Déplacement.NomPile.PILE_DE_BASE, "Le nom devrait être 'PILE_DE_BASE'");
            Assert.AreEqual(deplacement.Depuis.Numéro, -1, "Le numéro devrait être '-1'");
            Assert.AreEqual(deplacement.Vers.Nom, Déplacement.NomPile.COLONNE, "Le nom devrait être 'COLONNE'");
            Assert.AreEqual(deplacement.Vers.Numéro, 2, "Le numéro devrait être '2'");
            Assert.AreEqual(deplacement.Depuis.GetType(), typeof(Déplacement.Pile), "Devrait retourner un 'Déplacement.Pile'");
            Assert.AreEqual(deplacement.Vers.GetType(), typeof(Déplacement.Pile), "Devrait retourner un 'Déplacement.Pile'");


            deplacement = new("C4 V1");
            Assert.AreEqual(deplacement.Depuis.Nom, Déplacement.NomPile.COLONNE, "Le nom devrait être 'COLONNE'");
            Assert.AreEqual(deplacement.Depuis.Numéro, 4, "Le numéro devrait être '4'");
            Assert.AreEqual(deplacement.Vers.Nom, Déplacement.NomPile.CASE_LIBRE, "Le nom devrait être 'CASE_LIBRE'");
            Assert.AreEqual(deplacement.Vers.Numéro, 1, "Le numéro devrait être '1'");
            Assert.AreEqual(deplacement.Depuis.GetType(), typeof(Déplacement.Pile), "Devrait retourner un 'Déplacement.Pile'");
            Assert.AreEqual(deplacement.Vers.GetType(), typeof(Déplacement.Pile), "Devrait retourner un 'Déplacement.Pile'");
        }

        [TestMethod]
        public void TestGetBaseAcceptant()
        {
            Carte c1 = new Carte(8, Carte.Enseigne.PIQUE, true);
            Carte c2 = new Carte(9, Carte.Enseigne.COEUR, true);
            Carte c3 = new Carte(7, Carte.Enseigne.CARREAU, true);


            Freecell freecell = new ();

            Pile?  a = freecell.GetBaseAcceptant(c1);

            Assert.AreEqual(a.Nom, "B", "Le nom de la pile devrait être 'B'");
            Assert.AreEqual(a.Numéro, 1, "Le numéro de pile devrait être '1'");

            freecell.GetBaseAcceptant(c1).Déposer(c1);

            Pile? b = freecell.GetBaseAcceptant(c2);
            Assert.AreEqual(b.Nom, "B", "Le nom de la pile devrait être 'B'");
            Assert.AreEqual(b.Numéro, 2, "Le numéro de pile devrait être '2'");
            
            Pile? c = freecell.GetBaseAcceptant(c3);
            Assert.AreEqual(c.Nom, "B", "Le nom de la pile devrait être 'B'");
            Assert.AreEqual(c.Numéro, 1, "Le numéro de pile devrait être '1'");
        }
    }
}
