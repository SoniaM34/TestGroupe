using LeRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTest
{
    class RestaurantBuilder
    {
        private Restaurant _restaurant = new Restaurant();
        private string nom;
        public RestaurantBuilder Begin(String nom)
        {
            _restaurant.nom = nom;
            return this;
        }

        public RestaurantBuilder WithServer(Serveur serveur)
        {
            _restaurant.listServeur.Add(serveur);
            return this;
        }
        public RestaurantBuilder WithCreateServer(int nbrServeur)
        {
            _restaurant.createServeurs(5);
            return this;
        }
        public RestaurantBuilder WithImplServer(List<Commande> commandes)
        {
            _restaurant.implementeServeur(commandes);
            return this;
        }

        public Restaurant Build()
        {
            return _restaurant;
        }
    }
}
