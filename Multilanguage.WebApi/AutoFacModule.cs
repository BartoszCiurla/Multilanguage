using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Logging;
using Multilanguage.Service.Utility.ChainOfResponsibility.PizzasForLanguage;
using Multilanguage.Service.Pizza;
using Multilanguage.Repository.MongoDb;
using Multilanguage.Model.Pizza;

namespace Multilanguage.WebApi
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method in ConfigureServices.
            //builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
            //    .As<IValuesService>()
            //    .InstancePerLifetimeScope();
            builder.RegisterType<MongoRepository<Pizza>>().As<IMongoRepository<Pizza>>().WithParameter("connectionString", "mongodb://localhost:27017").WithParameter("database", "PizaaStore");
            builder.RegisterType<PizzasWithLanguageConditions>().As<IPizzasWithLanguageConditions>();
            builder.RegisterType<GetPizzaService>().As<IGetPizzaService>();
        }
    }
}
