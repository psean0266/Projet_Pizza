using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace projet_pizza
{

    class pizza
    {
        string nom;
        float prix;
        bool vegetarienne;
        List<string> ingredients;

        public pizza (string nom , float prix, bool vegetarienne, List<string> ingredients)
        {
            this.nom = nom;
            this.prix = prix;
            this.vegetarienne = vegetarienne;
            this.ingredients = ingredients;

        }

        public void Afficher()
        {
            //string badgeVegetarienne = " (V)";

            //if (!vegetarienne)
            //{
            //    badgeVegetarienne = " ";
            //}

            /* nom = nomMajiscules[0] + nomMinuscules.Substring(1);*/  // Nom de la prémière lettre en majuscule et démarrer à partir de deuxième caractère en minuscule

            string nomAfficher = FormatPremiereLettreMajusscules(nom);

            string badgeVegetarienne = vegetarienne ? " (V)" : " ";  // Si c'est vrai (V) sinon "" ? - : sinon

            //var ingredientsAfficher = new List<string>();

            //foreach (var ingredient in ingredients) {

            //    ingredientsAfficher.Add(FormatPremiereLettreMajusscules (ingredient));
            //}
            
            var ingredientsAfficher = ingredients.Select(i => FormatPremiereLettreMajusscules(i)).ToList();
            
            Console.WriteLine(" " + nomAfficher + badgeVegetarienne+" - "+ prix+"$");   
            Console.WriteLine(string.Join(", ", ingredientsAfficher)); // placer des virgules entre les element de la liste
            Console.WriteLine();
 
        }

        private static string FormatPremiereLettreMajusscules(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            
            string nomMinuscules = s.ToLower();
            string nomMajiscules = s.ToUpper();

            string resultat = nomMajiscules[0] + nomMinuscules[1..];

            return resultat;
        }

    }
     class Program
    {
        static void Main(string[] args)
        {


            var listepizzas = new List<pizza>
            {
                new pizza("4 fromages", 11.5f, true, new List<string>{"Fromage de chèvre", "Canta","Mozarella"}),
                new pizza("indienne", 10.5f, false, new List<string>{"Poulet", "Oignon","Mozarella"} ),
                new pizza("mexicaine", 13f, false, new List<string>{"Boeuf", "tomate","Mozarella, persil"}),
                new pizza("Margherita", 8f, true, new List<string>{"sauce tomate","Mozarella"}),
                new pizza("calzone", 12f, false,new List<string>{"kebab", "Oignon","Mozarella"}),
                new pizza("complète", 9.5f, false,new List<string>{"saumon", "Oignon","Mozarella, tomate"}),

            };

            foreach (var pizza in listepizzas)
            {

                pizza.Afficher();
            }
        }
    }
}
