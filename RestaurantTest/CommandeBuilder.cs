using LeRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTest
{
    public class CommandeBuilder
    {
        private Commande commande = new Commande();
        List<Commande> listCommande = new List<Commande>();
        public List<Commande>  Begin(int id,Client client, double montant)
        {
            commande.idCommande = id;
            commande.client = client;
            commande.prix = montant;
            listCommande.Add(commande);
            return listCommande;
           
        }
        public CommandeBuilder Build()
        {
            return this;
        }
    }
}
