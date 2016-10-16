using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Owin;
using Multilanguage.Service.Utility.ChainOfResponsibility.PizzasForLanguage;
using Multilanguage.Service.Pizza;
using Multilanguage.Repository.MongoDb;
using Multilanguage.Model.Pizza;

namespace Multilanguage.WebApi
{
    public class Startup
    {
        //public IContainer ApplicationContainer { get; private set; }
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy());
           
        }

        //with .net default DI 
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    // ASP.NET Core docs for Autofac are here:
        //    // http://autofac.readthedocs.io/en/latest/integration/aspnetcore.html
        //    //
        //    // Add framework services.

           
        //    // Create and return the service provider.
        //    services.AddSingleton<IMongoRepository<Pizza>>(new MongoRepository<Pizza>("mongodb://localhost:27017", "PizaaStore"));
        //    //services.AddScoped<IMongoRepository<Pizza>, new MongoRepository<Pizza>()>();
        //    services.AddScoped<IPizzasWithLanguageConditions, PizzasWithLanguageConditions>();
        //    services.AddScoped<IGetPizzaService, GetPizzaService>();
        //}

        //with autofac
        //public IServiceProvider ConfigureServices(IServiceCollection services)
        //{
        //    // ASP.NET Core docs for Autofac are here:
        //    // http://autofac.readthedocs.io/en/latest/integration/aspnetcore.html
        //    //
        //    // Add framework services.

        //    // Create the Autofac container builder.
        //    var builder = new ContainerBuilder();

        //    // Add any Autofac modules or registrations.
        //    builder.RegisterModule(new AutoFacModule());

        //    // Populate the services.
        //    builder.Populate(services);

        //    // Build the container.
        //    this.ApplicationContainer = builder.Build();

        //    // Create and return the service provider.
        //    return new AutofacServiceProvider(this.ApplicationContainer);
        //}
    }
}
