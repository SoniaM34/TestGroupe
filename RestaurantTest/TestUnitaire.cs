using FluentAssertions;
using LeRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantTest
{
    public class TestUnitaire
    {
        [Fact(DisplayName = "Test Restaurant revenue null")]
        void TestSystemeRestaurant()
        {
            var restaurant = new RestaurantBuilder().Begin("Macdonald").Build();
            restaurant.revenue().Should().Be(0);
        }

        [Fact(DisplayName = "Test Restaurant revenue value")]
        void TestSystemeRestaurantRevenue()
        {
            double montant = 110;
            var serv = new ServeurBuilder().Begin(110).Build();
            
            var restaurant = new RestaurantBuilder()
                .Begin("Macdonald")
                .WithServer(serv).Build();
            restaurant.revenue().Should().Be(110);
        }

        [Fact(DisplayName = "Test  null")]
        void TestSystemeServeur()
        {
            var serveur = new ServeurBuilder().Begin("Henri").Build(); 
            serveur.revenue().Should().Be(0);
        }

        [Fact(DisplayName = "Test  values")]
        void TestSystemeServeurValues()
        {
            var serveur = new ServeurBuilder()
                .Begin(110).Build();
            serveur.revenue().Should().Be(110);
        }



        [Fact(DisplayName = "Test  create server function")]
        void TestSystemeServeurCreateServeur()
        {
            var restaurant = new RestaurantBuilder().Begin("Macodnald")
                .WithCreateServer(5).Build();
            restaurant.listServeur.Count.Should().Be(5);
        }

        [Fact(DisplayName = "Test  create server function")]
        void TestSystemeServeurRevenue()
        {
            Serveur serv = new();
            double montant = 20;
            Client client = new();
            var commande = new CommandeBuilder().Begin(1, client, montant);
            var restaurant = new RestaurantBuilder().
            Begin("Macdonald").WithImplServer(commande)
            .WithServer(serv).Build();
            restaurant.revenue().Should().Be(20);
        }







        /*
        [Fact(DisplayName = "Test système changement d'heure " +
            "les boissons contenant plus de 15 % d'alchool ne peuvent etre" +
            "servi après 1h59 donc la commande n'es pas prise en compte")]
        void TestSystemeChangementheure()
        {
            var pierre = new Serveur("Pierre");
            var restaurant = new Restaurant();
            restaurant.listServeur.Add(pierre);

            List<string> listBoisson = new();
            listBoisson.Add("Vodka");
            var commande = new Commande("n°33",new DateTime(2022, 3, 28, 2, 59, 0),listBoisson);
            Assert.Null( commande.nom);
        }
        */

    }
           
}
