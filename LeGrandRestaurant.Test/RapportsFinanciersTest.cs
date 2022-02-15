using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Xunit;

namespace LeGrandRestaurant.Test
{
    public class RapportsFinanciersTest
  
    {
        
        /*  var restaurants = Enumerable
           .Range(0, nbrRestaurant)
           .Select(_ =>
           {
               var restaurant = new RestaurantBuilder()
                   .ayantXServeur(
                       (ushort)nbrServeur, 
                       out var serveurDuRestaurant)
                   .Build();

               tousLesServeurs.AddRange(serveurDuRestaurant);

               return restaurant;
           })
           .ToArray();
*/
        // var franchise = new Franchise(restaurants);
/*
        [Fact(DisplayName = "Étant donné un nouveau serveur, alors son chiffre d'affaire est nul")]
        public void Serveur_Initial()
        {
            var serveur = new Serveur();

            var chiffreAffaires = serveur.ChiffreAffaires;

            Assert.Equal(0, chiffreAffaires);
        }

        [Fact(DisplayName ="Étant donné un nouveau serveur, " +
                           "Quand un client passe une commande, " +
                           "Alors son chiffre d'affaire est augmenté de son montant.")]
        public void Serveur_Increment()
        {
            double montantCommande = 64.5;
            var serveur = new Serveur();
            var client = new Client();

            serveur.PrendreCommande(client, montantCommande);

            var chiffreAffaires = serveur.ChiffreAffaires;
            Assert.Equal(montantCommande, chiffreAffaires);
            
        }
        */
        
         [Fact(DisplayName = "ÉTANT DONNÉ un nouveau serveur" +
                            "QUAND on récupére son chiffre d'affaires" +
                            "ALORS celui - ci est à 0")]
        public void Serveur_Affectation_Table()
        {

            //ÉTANT DONNÉ un nouveau serveur
            var serveur = new Serveur();

            //QUAND on récupére son chiffre d'affaires
            serveur.getChiffreAffaire();

            //ALORS celui - ci est à 0
            Assert.Equal(serveur.getChiffreAffaire(), 0);
        }


        [Fact(DisplayName = "ÉTANT DONNÉ un nouveau serveur" +
                            "QUAND il prend une commande" +
                            "ALORS son chiffre d'affaires est le montant de celle-ci")]
        public void Serveur_Commande()
        {

            //ÉTANT DONNÉ un nouveau serveur
            var serveur = new Serveur();
            decimal prixCommande = new decimal(15.10);


            //QUAND il prend une commande
            serveur.AddCommande(prixCommande);

            //ALORS son chiffre d'affaires est le montant de celle-ci
            Assert.Equal(serveur.getChiffreAffaire(), prixCommande);
        }

        [Fact(DisplayName = "ÉTANT DONNÉ un serveur ayant déjà pris une commande"+
                            "QUAND il prend une nouvelle commande"+
                            "ALORS son chiffre d'affaires est la somme des deux commandes")]
        public void Serveur_Total_Commande()
        {

            //ÉTANT DONNÉ un serveur ayant déjà pris une commande
            var serveur = new Serveur();
            decimal prixPremiereCommande = new decimal(33);
            serveur.AddCommande(prixPremiereCommande);

            //QUAND il prend une nouvelle commande
            decimal prixSecondeCommande =new decimal(20.10);
            serveur.AddCommande(prixSecondeCommande) ;
            decimal ServeurTotalCommande = prixPremiereCommande + prixSecondeCommande;

            //ALORS son chiffre d'affaires est la somme des deux commandes
            Assert.Equal(serveur.getChiffreAffaire(), ServeurTotalCommande);
        }
        
        
        // scope restaurant 
        [Fact(DisplayName = @"ÉTANT DONNÉ un restaurant ayant X serveurs
        QUAND tous les serveurs prennent une commande d'un montant Y
            ALORS le chiffre d'affaires de la franchise est X * Y
            CAS(X = 0; X = 1; X = 2; X = 100)
        CAS(Y = 1.0)")]
        
        
        public void chiffreAffaireProduitCommande()
        {
            decimal montantCommande =new decimal(10);
            
            int nbrServeur = 6;
            int nbrRestaurant = 1;
            var restaurant = new RestaurantBuilder()
                .ayantXServeur(
                    (ushort)nbrServeur,
                    out var serveurDuRestaurant)
                .Build();

            foreach (var serveur in serveurDuRestaurant)
            {
                serveur.PrendreCommande(montantCommande);
            }
            Assert.Equal(60,restaurant.ChiffreAffaires);
        }
        
        // scope franchise 
        [Fact(DisplayName = @"	SCOPE Franchise
		ÉTANT DONNÉ une franchise ayant X restaurants de Y serveurs chacuns
		QUAND tous les serveurs prennent une commande d'un montant Z
		ALORS le chiffre d'affaires de la franchise est X * Y * Z
		CAS(X = 0; X = 1; X = 2; X = 1000)
		CAS(Y = 0; Y = 1; Y = 2; Y = 1000)
		CAS(Z = 1.0)")]


        public void chiffreAffaireProduitCommandeFranchise()
        {
            decimal montantCommande =new decimal(10);
            int nbrServeur = 6;
            int nbrRestaurant = 1;
            var restaurant = new RestaurantBuilder()
                .ayantXServeur(
                    (ushort)nbrServeur,
                    out var serveurDuRestaurant)
                .Build();

            foreach (var serveur in serveurDuRestaurant)
            {
                serveur.PrendreCommande(montantCommande);
            }
            Assert.Equal(60,restaurant.ChiffreAffaires);   
        }


    }
}
