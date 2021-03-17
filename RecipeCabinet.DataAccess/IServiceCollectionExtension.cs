using Microsoft.Extensions.DependencyInjection;
using RecipeCabinet.DataAccess.Common;
using RecipeCabinet.DataAccess.Ingredient;
using RecipeCabinet.DataAccess.Rating;
using RecipeCabinet.DataAccess.Metadata;
using RecipeCabinet.DataAccess.Cabinet;

namespace RecipeCabinet.DataAccess
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryConnectors(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseContext, DatabaseContext>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IIngredientTypeRepository, IngredientTypeRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IReviewImageRepository, ReviewImageRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IMeasurementRepository, MeasurementRepository>();
            services.AddTransient<IMetadataTypeRepository, MetadataTypeRepository>();
            services.AddTransient<IMetadataTaggingRepository, MetadataTaggingRepository>();
            services.AddTransient<ICabinetRepository, CabinetRepository>();

            return services;
        }
    }
}
