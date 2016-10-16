using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;
using Multilanguage.Model.Pizza;
using Multilanguage.Service.Utility.ChainOfResponsibility.PizzasForLanguage;
using Multilanguage.Service.Pizza;

namespace Multilanguage.WebApi.Module
{
    public class PizzaModule:NancyModule
    {
        //w tej wersji .net nie sposób zrobić Di autofac + nancy 

        private readonly Repository.MongoDb.MongoRepository<Pizza> _repository;
        private readonly IPizzasWithLanguageConditions _pizzasWithLanguageConditions;
        private readonly IGetPizzaService _getPizzaService;
        public PizzaModule()
        {
            _repository = new Repository.MongoDb.MongoRepository<Pizza>("mongodb://localhost:27017", "PizaaStore");
            _pizzasWithLanguageConditions = new PizzasWithLanguageConditions();
            _getPizzaService = new GetPizzaService(_repository, _pizzasWithLanguageConditions);

            Get("/pizza/{id}/{language}", args => _getPizzaService.GetById(args.id, args.language));
            Get("/pizzaList/{language}", args => _getPizzaService.GetAll(args.language));
        }
    }
}
