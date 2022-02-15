using System;
using System.Linq;

namespace LeGrandRestaurant.Test
{
    public class RestaurantBuilder
    {
        public Serveur[] _serveurs = Array.Empty<Serveur>();
        
        public static Restaurant stub => new RestaurantBuilder().Build();


        public Restaurant Build() => new Restaurant(_serveurs);

        public RestaurantBuilder ayantPourServeurs(Serveur[] serveurs)
        {
            _serveurs = serveurs;
            return this;
            //  https://stackoverflow.com/questions/488071/c-sharp-constructors-with-same-parameter-signatures

        }

        public RestaurantBuilder ayantXServeur(int nombreServeurs,out Serveur[] serveursCree)
        {
            _serveurs = Enumerable
                .Range(0, nombreServeurs)
                .Select(_ => ServeurBuilder.Stub)
                .ToArray();

            serveursCree = _serveurs;

            return this;
            return this;
        }

    }
}