using System.Collections.Generic;
using System.Linq;

namespace LeGrandRestaurant
{
    public class Franchise
    {
        private readonly Restaurant[] _restaurants ;

        public Franchise(Restaurant[] restaurants)
        {
            this._restaurants = restaurants;
        }
        public decimal ChiffreAffaires
            => _restaurants.Sum(restaurant => restaurant.ChiffreAffaires);
    }
}