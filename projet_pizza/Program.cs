using System;
using System.Collections.Generic;

namespace projet_pizza
{

    class pizza
    {
        string nom;
        float prix;
        bool vegetarienne;

        public pizza (string nom , float prix, bool vegetarienne)
        {
            this.nom = nom;
            this.prix = prix;
            this.vegetarienne = vegetarienne;

        }

        public void Afficher()
        {
            //string badgeVegetarienne = " (V)";

            //if (!vegetarienne)
            //{
            //    badgeVegetarienne = " ";
            //}

            string badgeVegetarienne = vegetarienne ? " (V)" : " ";  // Si c'est vrai (V) sinon "" ? - : sinon

               Console.WriteLine(" " + nom +badgeVegetarienne+" - " + prix+"$");
 
        }

    }
     class Program
    {
        static void Main(string[] args)
        {

            var listepizzas = new List<pizza>
            {
                new pizza("4 promages", 11.5f, true),
                new pizza("indienne", 10.5f, false),
                new pizza("mexicaine", 13f, false),
                new pizza("Margherita", 8f, true),
                new pizza("calzone", 12f, false),
                new pizza("calzone", 9.5f, false),

            };

            foreach(var pizza in listepizzas) {

                pizza.Afficher();
            }
        }
    }
}
