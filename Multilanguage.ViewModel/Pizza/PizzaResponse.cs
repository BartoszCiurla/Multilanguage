namespace Multilanguage.ViewModel.Pizza
{
    public class PizzaResponse
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LanguageCode { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name} {LanguageCode}";
        }
    }
}
