using CQRS.Domain.DataAcess;
using CQRS.Infrastructure.Repositories.MongoDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CQRS.CrossCutting.DependencyInjection
{
    public static class RepositoriesServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            // requires using Microsoft.Extensions.Options
            services.Configure<MongoDatabaseSettings>(
                configuration.GetSection(nameof(MongoDatabaseSettings)));

            services.AddSingleton<IMongoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);

            services.AddTransient<IProdutoReadRepository, ProdutoReadRepository>();
            services.AddTransient<IProdutoWriteRepository, ProdutoWriteRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}