using Microsoft.Extensions.DependencyInjection;
using RecipeCabinet.DataAccess.Ingredient;

namespace RecipeCabinet.DataAccess
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryConnectors(this IServiceCollection services)
        {
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            return services;
        }
    }
}
