using System.Linq;
using Multilanguage.Repository.MongoDb;
using Multilanguage.Service.Utility.ChainOfResponsibility.PizzasForLanguage;
using Multilanguage.ViewModel.Pizza;

namespace Multilanguage.Service.Pizza
{
    public class GetPizzaService: IGetPizzaService
    {
        private readonly IMongoRepository<Model.Pizza.Pizza> _mongoRepository;
        private readonly IPizzasWithLanguageConditions _pizzasWithLanguageConditions;

        public GetPizzaService(IMongoRepository<Model.Pizza.Pizza> mongoRepository, IPizzasWithLanguageConditions pizzasWithLanguageConditions)
        {
            _mongoRepository = mongoRepository;
            _pizzasWithLanguageConditions = pizzasWithLanguageConditions;
        }

        public PizzaResponse[] GetAll(string language)
        {
            return _pizzasWithLanguageConditions.GetPizzas(_mongoRepository.Get(), language);
        }
        public PizzaResponse GetById(string id, string language)
        {

            return _pizzasWithLanguageConditions.GetPizzas(_mongoRepository.Get().Where(x => x.Id.Equals(_mongoRepository.ParseParamId(id))), language).FirstOrDefault();
        }
    }
}
