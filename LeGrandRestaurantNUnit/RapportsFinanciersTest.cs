using LeGrandRestaurant;
using LeGrandRestaurant.Test;
using NUnit.Framework;

namespace LeGrandRestaurantNUnit
{
    public class RapportsFinanciersTest
    {

        [TestCase(TestName = "Etant donn� un nouveau serveur" +
                             "Quand on r�cup�re son chiffre d'affaires" +
                             "Alors il est � 0")]
        public void Serveur_Affectation_Table()
        {
            //Etant donn� un nouveau serveur
            var serveur = new Serveur();

            //Quand on r�cup�re son chiffre d'affaire
            var expResult = serveur.getChiffreAffaire();

            //Alors il est � 0
            Assert.AreEqual(expResult,0);
        }

        [TestCase(TestName = "Etant donn� un nouveau serveur" +
                            "Quand il prend une commande" +
                            "Alors son chiffre d'affaires est le montant de celle-ci")]
        public void Serveur_Commande()
        {

            //Etant donn� un nouveau serveur
            var serveur = new Serveur();
            decimal prixCommande = new decimal(15.10);

            //Quand il prend une commande
            serveur.AddCommande(prixCommande);

            //Alors son chiffre d'affaires est le montant de celle-ci
            Assert.AreEqual(serveur.getChiffreAffaire(), prixCommande);
        }


        [TestCase(TestName = "Etant donn� un serveur ayant d�j� pris une commande" +
                             "Quand il prend une nouvelle commande" +
                             "Alors son chiffre d'affaires est la somme des 2 commandes")]
        public void Serveur_Total_Commande()
        {
            //Etant donn� un serveur ayant d�j� pris une commande
            var serveur = new Serveur();
            decimal prixPremiereCommande = new decimal(33);
            serveur.AddCommande(prixPremiereCommande);

            //Quand il prend une nouvelle commande
            decimal prixSecondeCommande = new decimal(20.10);
            serveur.AddCommande(prixSecondeCommande);
            decimal ServeurTotalCommande = prixPremiereCommande + prixSecondeCommande;

            //Alors son chiffre d'affaires est la somme des deux commandes
            Assert.AreEqual(serveur.getChiffreAffaire(), ServeurTotalCommande);
        }

        [TestCase(TestName = "Etant donn� un restaurant ayant X serveurs" +
                             "Quand tous les serveurs prennent une commande d'un montant Y" +
                             "Alors le chiffre d'affaires de la franchise est X * Y" +
                             "Cas(X = 0; X = 1; X = 2; X = 100)" +
                             "Cas(Y = 1.0)")]
        public void Chiffre_Affaire_Produit_Commande()
        {
            //Etant donn� un serveur ayant d�j� pris une commande
            decimal montantCommande = new decimal(10);
            int nbrServeur = 6;
            int nbrRestaurant = 1;
            var restaurant = new RestaurantBuilder()
                .ayantXServeur(
                    (ushort)nbrServeur,
                    out var serveurDuRestaurant)
                .Build();

            //Quand tous les serveurs prennent une commande d'un montant Y
            foreach (var serveur in serveurDuRestaurant)
            {
                serveur.PrendreCommande(montantCommande);
            }

            //Alors le chiffre d'affaires de la franchise est X * Y
            Assert.AreEqual(60, restaurant.ChiffreAffaires);
        }
    }
}