using PizzaApp.extensions;

namespace PizzaApp.Model
{
    public class Pizza
    {
        //nom, prix, ingrédient7

        public string nom { get; set; }
        public string imageUrl { get; set; }
        public int prix { get; set; }
        public string[] ingredients { get; set; }

        public string PrixEuros
        {
            get { return prix + "€"; }
        }

        public string IngredientStr
        {
            get { return string.Join(",", ingredients); }
        }
        
        public string Titre
        {
            get { return nom.PremiereLettreMajuscule(); }
        }

        public Pizza()
        {
        }
    }
}