using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multilanguage.Model.Pizza;
using Multilanguage.Repository.MongoDb;
using Multilanguage.Service.Pizza;
using Multilanguage.Service.Utility.ChainOfResponsibility.PizzasForLanguage;
using Xunit;
using Xunit.Abstractions;

namespace Multilanguage.GetPizzaServiceTest
{
    //w tej wersji .net testy nie działają 
    public class GetPizzaServiceTest
    {
        private readonly MongoRepository<Pizza> _mongoRepository;
        private readonly IPizzasWithLanguageConditions _pizzasWithLanguageConditions;
        private IGetPizzaService _getPizzaService;
        private ITestOutputHelper _output;

        public GetPizzaServiceTest(ITestOutputHelper output)
        {
            _output = output;
            _mongoRepository = new MongoRepository<Pizza>("mongodb://localhost:27017", "PizaaStore");
            _pizzasWithLanguageConditions = new PizzasWithLanguageConditions();
            _getPizzaService = new GetPizzaService(_mongoRepository, _pizzasWithLanguageConditions);
        }
        [Fact]
        public void GetFrenchPizza()
        {
            var result = _getPizzaService.GetAll("fr-FR");

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var pizzaResponse in result)
            {
                Assert.Equal("fr-FR", pizzaResponse.LanguageCode);
                _output.WriteLine(pizzaResponse.ToString());
            }

        }

        [Fact]
        public void GetFrenchPizzaById()
        {
            var result = _getPizzaService.GetById("57e697257ae46124486316cb", "fr-FR");
            _output.WriteLine(result.ToString());
            Assert.NotNull(result);
            Assert.Equal(result.LanguageCode, "fr-FR");
            Assert.Equal(result.Id, "57e697257ae46124486316cb");
        }

        [Fact]
        public void GetRusPizza()
        {
            var result = _getPizzaService.GetAll("ru-RU");

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var pizzaResponse in result)
            {
                Assert.Equal("ru-RU", pizzaResponse.LanguageCode);
                _output.WriteLine(pizzaResponse.ToString());
            }
        }

        [Fact]
        public void GetRusPizzaById()
        {
            var result = _getPizzaService.GetById("57e697257ae46124486316ca", "ru-RU");
            _output.WriteLine(result.ToString());
            Assert.NotNull(result);
            Assert.Equal(result.LanguageCode, "ru-RU");
            Assert.Equal(result.Id, "57e697257ae46124486316ca");
        }

        [Fact]
        public void GetNotExistPizza()
        {
            var result = _getPizzaService.GetAll("brrr");

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var pizzaResponse in result)
            {
                //Assert.Equal("ru-RU", pizzaResponse.LanguageCode);
                _output.WriteLine(pizzaResponse.ToString());
            }
        }

        [Theory]
        [InlineData("57e697257ae46124486316c9", "sfds")]
        [InlineData("57e697257ae46124486316ca", "sfds")]
        [InlineData("57e697257ae46124486316cb", "sfds")]
        [InlineData("57e697257ae46124486316cc", "sfds")]
        public void GetNotExistPizzaById(string id, string language)
        {
            var result = _getPizzaService.GetById(id, language);
            _output.WriteLine(result.ToString());
            Assert.NotNull(result);
            //Assert.Equal(result.LanguageCode, "ru-RU");
            Assert.Equal(result.Id, id);
        }
    }
}
