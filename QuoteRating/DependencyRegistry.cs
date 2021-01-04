using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuoteRating.RatingEngine;

namespace QuoteRating
{
    public static class DependencyRegistry
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IQuoteService, QuoteService>();
        }
    }
}