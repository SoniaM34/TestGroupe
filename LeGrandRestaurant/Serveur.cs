namespace LeGrandRestaurant
{
    public class Serveur
    { 
        public decimal Commande{ get; set; }
        public decimal ChiffreAffaires { get; private set; }
        public Serveur()
        {
        }

        public Serveur(string nom)
        {
        }
     

        public void PrendreCommande( decimal montantCommande)
        {
            ChiffreAffaires = montantCommande;
        }

        public decimal getChiffreAffaire()
        {
          ;
          return ChiffreAffaires;
        }

        public void AddCommande(decimal prixSecondeCommande)
        {
            ChiffreAffaires += prixSecondeCommande;
        }
    }
}
