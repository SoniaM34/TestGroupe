using LeGrandRestaurant;
using LeGrandRestaurant.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MsTest_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod(displayName: "ETANT DONNE un nouveau serveur" +
                                 "QUAND on récupère son chiffre d'affaires" +
                                 "ALORS celui - est à 0")]

        public void Serveur_Affectation_Table()
        {

            //ÉTANT DONNÉ un nouveau serveur
            var serveur = new Serveur();

            //QUAND on récupére son chiffre d'affaires
            serveur.getChiffreAffaire();

            //ALORS celui - ci est à 0
            Assert.AreEqual(serveur.getChiffreAffaire(), 0);
        }

        [TestMethod(displayName: "ÉTANT DONNÉ un nouveau serveur" +
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
            Assert.AreEqual(serveur.getChiffreAffaire(), prixCommande);
        }

        [TestMethod(displayName: "ÉTANT DONNÉ un serveur ayant déjà pris une commande" +
                                 "QUAND il prend une nouvelle commande" +
                                 "ALORS son chiffre d'affaires est la somme des deux commandes")]

        public void Serveur_Total_Commande()
        {

            //ÉTANT DONNÉ un serveur ayant déjà pris une commande
            var serveur = new Serveur();
            decimal prixPremiereCommande = new decimal(33);
            serveur.AddCommande(prixPremiereCommande);

            //QUAND il prend une nouvelle commande
            decimal prixSecondeCommande = new decimal(20.10);
            serveur.AddCommande(prixSecondeCommande);
            decimal ServeurTotalCommande = prixPremiereCommande + prixSecondeCommande;

            //ALORS son chiffre d'affaires est la somme des deux commandes
            Assert.AreEqual(serveur.getChiffreAffaire(), ServeurTotalCommande);
        }


        [TestMethod(displayName:  "ÉTANT DONNÉ un restaurant ayant X serveurs" +
                                  "QUAND tous les serveurs prennent une commande d'un montant Y" +
                                  " ALORS le chiffre d'affaires de la restaurant est X * Y "+
                                  " CAS(X = 0; X = 1; X = 2; X = 100)" +
                                  " CAS(Y = 1.0)")]

        public void chiffreAffaireProduitCommande()
        {
            decimal montantCommande = new decimal(10);

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
            Assert.AreEqual(60, restaurant.ChiffreAffaires);
        }

    }
}