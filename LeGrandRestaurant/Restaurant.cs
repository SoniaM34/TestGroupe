using System.Collections.Generic;
using System.Linq;

namespace LeGrandRestaurant
{
    public class Restaurant
    {
        private readonly Serveur[] _listServeur;
        private readonly Client[] _clients;

        public Restaurant(Serveur[] serveur)
        {
            _listServeur = serveur;
        }
        public decimal ChiffreAffaires
         => _listServeur.Sum(serveur => serveur.ChiffreAffaires);
    }
}