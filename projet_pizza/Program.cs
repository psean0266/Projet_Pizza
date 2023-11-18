using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace projet_pizza
{
    
    class PizzaPersonalisee: pizza
    {
        static int NumeroPizzaPersonnalisee = 0;
        public PizzaPersonalisee():base ("Personnalisée ", 5f, false, null)
        {
            
            NumeroPizzaPersonnalisee++;
            nom = "Personnalisée" + NumeroPizzaPersonnalisee;
            ingredients = new List<string>();
            
            while (true)
            {
                Console.Write("Rentrez un ingrédient pour la pizza personnalisée "+NumeroPizzaPersonnalisee+ " (ENTER pour terminer): ");
                var ingredient = Console.ReadLine();


                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    break;
                }
                else if (!ingredients.Contains(ingredient))
                {
                    ingredients.Add(ingredient);
                }
                else
                {
                    Console.WriteLine("ERREUR: L'ingredient "+ingredient+" existe déjà la dans liste");
                }

                Console.WriteLine(string.Join(", ", ingredients));
                Console.WriteLine();
                //foreach(var ingred in ingredients)
                //{
                //    Console.WriteLine(ingred);
                //    Console.Write(string.Join(", ",ingred));

                //    Console.WriteLine();
                //}
            }
            
            Console.ReadLine();
            prix = 5 + ingredients.Count * 1.5f;
        }     

    }
    class pizza
    {
       protected string nom;
       public float prix { get; protected set; }
       public  bool vegetarienne { get; private set; }
       public  List<string> ingredients { get; protected set; }

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

            string nomAfficher = FormatPremiereLettreMajuscules(nom);

            string badgeVegetarienne = vegetarienne ? " (V)" : " ";  // Si c'est vrai (V) sinon "" ? - : sinon

            //var ingredientsAfficher = new List<string>();

            //foreach (var ingredient in ingredients) {

            //    ingredientsAfficher.Add(FormatPremiereLettreMajuscules (ingredient));
            //}
            
            var ingredientsAfficher = ingredients.Select(i => FormatPremiereLettreMajuscules(i)).ToList();
            
            Console.WriteLine(" " + nomAfficher + badgeVegetarienne+" - "+ prix+"$");   
            Console.WriteLine(string.Join(", ", ingredientsAfficher)); // placer des virgules entre les element de la liste
            Console.WriteLine();
 
        }

        private static string FormatPremiereLettreMajuscules(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            
            string nomMinuscules = s.ToLower();
            string nomMajiscules = s.ToUpper();

            string resultat = nomMajiscules[0] + nomMinuscules[1..];

            return resultat;
        }

        public bool ContientIngredient(string ingredient)
        {
            return ingredients.Where(i => i.ToLower().Contains("tomate")).ToList().Count > 0 ;
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
                new pizza("complète", 9.5f, false,new List<string>{"saumon", "Oignon","Mozarella","tomates"}),
                new PizzaPersonalisee(),
                new PizzaPersonalisee()

            };

            //listepizzas = listepizzas.OrderByDescending(p=> p.prix).ToList();   
            //listepizzas = listepizzas.OrderBy(p=> p.prix).ToList();

            float prixMin = listepizzas[0].prix;
            float prixMax = listepizzas[0].prix;
            pizza pizzaPrixMin = null;
            pizza pizzaPrixMax = null;    


            foreach (var pizza in listepizzas)
            {
                pizza.Afficher();

                if (prixMax < pizza.prix)
                {
                    prixMax = pizza.prix;
                    pizzaPrixMax = pizza; 
                }

                else if (prixMin > pizza.prix)

                {
                    prixMin = pizza.prix;
                    pizzaPrixMin = pizza;
                }

            }

            Console.WriteLine("Pizza la moins chère est : ");
            pizzaPrixMin.Afficher();

            Console.WriteLine();

            Console.WriteLine("Pizza la plus chère est de : " );
            pizzaPrixMax.Afficher();


            //Console.WriteLine("2--------------------QUE LES PIZZAS VEGETARIENNE--------------------------------");

            //Console.WriteLine();

            //listepizzas = listepizzas.Where(p => p.vegetarienne).ToList();

            //foreach (var pizza in listepizzas)
            //{
            //    pizza.Afficher();
            //}

            //Console.WriteLine("------------------------FIN DES PIZZAS VEGETARIENNE--------------------------------");




            Console.WriteLine("2--------------------QUE LES PIZZAS AVEC TOMATES--------------------------------");

            Console.WriteLine();

            //listepizzas = listepizzas.Where(p => p.ingredients.Where(i => i.ToLower().Contains("tomate")).ToList().Count>0).ToList();

            listepizzas = listepizzas.Where(p => p.ContientIngredient("tomate")).ToList();

            foreach (var pizza in listepizzas)
            {
                pizza.Afficher();

            }

            Console.WriteLine("------------------------FIN LES PIZZAS AVEC TOMATES--------------------------------");
        }
     }
}
