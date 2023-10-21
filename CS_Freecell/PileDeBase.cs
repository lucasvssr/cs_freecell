namespace CS_Freecell
{
    public class PileDeBase : Pile
    {
        public override string Nom { get; set; }
        public override int Numéro { get; set; }

        public PileDeBase()
        {
            Nom = Convert.ToString("B");
        }

        public override bool PeutDéposer(Carte c)
        {
            if (EstVide)
            {
                if(c.Face.Valeur == 1) { return true; }                
            }
            else
            {
                if ((c.Face.Valeur > Dernière.Face.Valeur) && (c.Couleur == Dernière.Couleur))
                {
                    return true;
                }
            }
            
            return false;
        }

        public override bool PeutRetirer()
        {
            return base.PeutRetirer();
        }
    }
}
