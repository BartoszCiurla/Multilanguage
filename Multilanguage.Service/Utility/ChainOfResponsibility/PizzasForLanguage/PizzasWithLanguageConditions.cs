using System.Linq;
using Multilanguage.Model.Pizza;
using Multilanguage.ViewModel.Pizza;

namespace Multilanguage.Service.Utility.ChainOfResponsibility.PizzasForLanguage
{
    public class PizzasWithLanguageConditions: IPizzasWithLanguageConditions
    {
        private readonly ForSelectedLanguage _forLanguage = new ForSelectedLanguage();
        private readonly ForEnglishLanguage _forEnglish = new ForEnglishLanguage();
        private readonly ForPolishLanguage _forPolish = new ForPolishLanguage();
        private readonly AnyPizzas _anyPizzas = new AnyPizzas();

        public PizzasWithLanguageConditions()
        {
            _forLanguage.SetSuccessor(_forEnglish);
            _forEnglish.SetSuccessor(_forPolish);
            _forPolish.SetSuccessor(_anyPizzas);
        }

        public PizzaResponse[] GetPizzas(IQueryable<Model.Pizza.Pizza> query, string language)
        {
            return _forLanguage.HandleRequest(query, language);
        }
    }
}
