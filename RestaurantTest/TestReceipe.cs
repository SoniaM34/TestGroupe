using LeRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantTest
{
    public class TestReceipe
    {
        [Theory(DisplayName = "Simulation tous les serveurs prennent une commande " +
                "d'un montant Y")]
        [InlineData(5)]
        [InlineData(10)]
        public void CommandeTousLesServeurs(int nbrServeur)
        {
            //Arrange
            double firstCommandePrice = 100;
            //int nbrServeur = 10;
            var restaurant = new Restaurant("Michelin");
            Client client = new Client("Srah");
            List<Commande> commande = new List<Commande>();
            //Act
            commande.Add(new Commande(1, client, firstCommandePrice));
            restaurant.createServeurs(nbrServeur);
            restaurant.implementeServeur(commande);
            //Assert
            Assert.Equal(firstCommandePrice * 10, restaurant.revenue());
        }
    }
}
