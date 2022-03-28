using LeRestaurant;
using System;

namespace RestaurantTest
{
    public class ServeurBuilder
    {
        private Serveur _Serveur = new Serveur();

        public ServeurBuilder Begin(String nom)
        {
            _Serveur.nom = nom;
            return this;
        }
        public ServeurBuilder Begin(double chiffreAffaire)
        {
            _Serveur.chiffreAffaires = chiffreAffaire;
            return this;
        }

        public Serveur Build()
        {
            return _Serveur;
        }


    }
}
