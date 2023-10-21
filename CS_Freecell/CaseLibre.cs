namespace CS_Freecell
{
    public class CaseLibre : Pile
    {
        public override string Nom { get; set; }
        public override int Numéro { get; set; }

        public CaseLibre()
        {
            Nom = "V";
        }
        
        public override bool PeutDéposer(Carte c)
        {
            return EstVide;
        }

        public override bool PeutRetirer()
        {
            return base.PeutRetirer();
        }
    }
}
