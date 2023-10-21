namespace CS_Freecell
{
    public class Colonne : Pile
    {
        public override string Nom { get; set; }
        public override int Numéro { get; set; }

        public Colonne()
        {
            Nom = "C";
        }

        public override bool PeutDéposer(Carte c)
        {
            if(EstVide)
            {
                return true;
            }
            if (Dernière.PeutCouvrir(c))
            {
                return true;
            }
            return false;
        }

        public override bool PeutRetirer()
        {
            return base.PeutRetirer();
        }
    }
}
