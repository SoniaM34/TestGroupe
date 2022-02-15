using System;
using System.Linq;

namespace LeGrandRestaurant.Test
{
    public class FranchiseBuilder
    {
        public Franchise[] _franchise = Array.Empty<Franchise>();
        public FranchiseBuilder ayantXFranchise(int nombreServeurs,out Serveur[] serveursCree)
        {
            _franchise = Enumerable
                .Range(0, nombreServeurs)
                .Select(_ => RestaurantBuilder.Stub)
                .ToArray();

            serveursCree = _serveurs;

            return this;
        }
    }
}