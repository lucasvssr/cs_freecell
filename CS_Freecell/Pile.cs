namespace CS_Freecell  
{
    public abstract class Pile
    {
        protected List<Carte> _cartes = new List<Carte>();

        public int Count { get { return _cartes.Count; } }
        public Carte? Dernière { get { return _cartes.LastOrDefault(); } }
        public bool EstVide { get { return Count == 0; } }
        public abstract string Nom { get; set; }
        public abstract int Numéro { get; set; }

        public void Déposer(Carte c)
        {
            _cartes.Add(c);
        }

        public void Effacer()
        {
            _cartes.Clear();
        }

        public abstract bool PeutDéposer(Carte c);

        public virtual bool PeutRetirer()
        {
            return EstVide == false;
        }

        public Carte Retirer()
        {
            if (EstVide)
            {
                throw new InvalidOperationException("La pile est vide");
            }

            Carte retirer = Dernière;
            _cartes.Remove(Dernière);
            return retirer;
        }

        public override string ToString()
        {
            return Nom + Numéro;
        }

        public IEnumerator<Carte> GetEnumerator()
        {
            foreach (Carte c in _cartes)
            {
                yield return c;
            }
        }
    }
}
