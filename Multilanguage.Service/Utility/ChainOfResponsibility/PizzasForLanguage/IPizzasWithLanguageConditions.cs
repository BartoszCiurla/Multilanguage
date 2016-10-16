using System.Linq;
using Multilanguage.ViewModel.Pizza;

namespace Multilanguage.Service.Utility.ChainOfResponsibility.PizzasForLanguage
{
    public interface IPizzasWithLanguageConditions
    {
        PizzaResponse[] GetPizzas(IQueryable<Model.Pizza.Pizza> query, string language);
    }
}
