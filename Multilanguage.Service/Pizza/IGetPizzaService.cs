using Multilanguage.ViewModel.Pizza;

namespace Multilanguage.Service.Pizza
{
    public interface IGetPizzaService
    {
        PizzaResponse[] GetAll(string language);
        PizzaResponse GetById(string id, string language);
    }
}
