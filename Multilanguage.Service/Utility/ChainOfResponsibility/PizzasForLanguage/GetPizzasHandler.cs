using System.Linq;
using Multilanguage.Model.Pizza;
using Multilanguage.ViewModel.Pizza;

namespace Multilanguage.Service.Utility.ChainOfResponsibility.PizzasForLanguage
{
    public abstract class GetPizzasHandler
    {
        private GetPizzasHandler _succcessor;
        protected string English = "en-GB";
        protected string Polish = "pl-PL";
        public void SetSuccessor(GetPizzasHandler successor)
        {
            _succcessor = successor;
        }

        public abstract PizzaResponse[] HandleRequest(IQueryable<Model.Pizza.Pizza> query, string language);

        protected PizzaResponse[] GetPizzas(IQueryable<Model.Pizza.Pizza> query, string language)
        {
            var result =
                query.SelectMany(pizza => pizza.Contents,
                    (pizza, content) => new PizzaResponse
                    {
                        Id = pizza.Id,
                        ImageUrl = pizza.ImageUrl,
                        Price = pizza.Price,
                        LanguageCode = content.LanguageCode,
                        Name = content.Name,
                        Description = content.Description
                    })
                    .Where(x => x.LanguageCode == language)
                    .ToArray();
            return !result.Any() ? _succcessor.HandleRequest(query, language) : result;
        }

        protected PizzaResponse[] GetAnyPizzas(IQueryable<Model.Pizza.Pizza> query)
        {
            return query.SelectMany(pizza => pizza.Contents,
                    (pizza, content) => new PizzaResponse
                    {
                        Id = pizza.Id,
                        ImageUrl = pizza.ImageUrl,
                        Price = pizza.Price,
                        LanguageCode = content.LanguageCode,
                        Name = content.Name,
                        Description = content.Description
                    })
                    .Distinct()
                    .ToArray();
        }
    }

    public class ForSelectedLanguage : GetPizzasHandler
    {
        public override PizzaResponse[] HandleRequest(IQueryable<Model.Pizza.Pizza> query, string language)
        {
            return GetPizzas(query, language);
        }
    }
    public class ForEnglishLanguage : GetPizzasHandler
    {
        public override PizzaResponse[] HandleRequest(IQueryable<Model.Pizza.Pizza> query, string language)
        {
            return GetPizzas(query, English);
        }
    }

    public class ForPolishLanguage : GetPizzasHandler
    {
        public override PizzaResponse[] HandleRequest(IQueryable<Model.Pizza.Pizza> query, string language)
        {
            return GetPizzas(query, Polish);
        }
    }

    public class AnyPizzas : GetPizzasHandler
    {
        public override PizzaResponse[] HandleRequest(IQueryable<Model.Pizza.Pizza> query, string language)
        {
            return GetAnyPizzas(query);
        }
    }
}
