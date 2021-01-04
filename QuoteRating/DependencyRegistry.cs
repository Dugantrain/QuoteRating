using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuoteRating.RatingEngine;
using QuoteRating.Repositories;
using QuoteRating.Services;

namespace QuoteRating
{
    public static class DependencyRegistry
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IQuoteService, QuoteService>();
            var useInMemoryPersistence = false;
            var useInMemoryPersistenceSection = configuration.GetSection("useInMemoryPersistence");
            if (useInMemoryPersistenceSection != null)
                useInMemoryPersistence = Convert.ToBoolean(useInMemoryPersistenceSection.Value);
            if (useInMemoryPersistence)
            {
                services.AddSingleton<IRepository, InMemoryRepository>();
            }
            else
            {
                services.AddSingleton<IRepository, JsonRepository>();

            }
        }
    }
}