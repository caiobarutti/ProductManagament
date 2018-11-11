using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Domain.Products.Csv;
using ProductManagement.Domain.Products.Factory;
using ProductManagement.Domain.Products.Repository;
using ProductManagement.Domain.Products.Services;
using ProductManagement.Domain._base;
using ProductManagement.Infra.Database.Repositories;
using ProductManagement.Infra.Database._base;
using ProductManagement.Infra.Sheets;

namespace ProductManagement.DI
{
    public static class ConfigureDI
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(ICsvParser), typeof(CsvParser));
            services.AddScoped(typeof(IImportProductFromCsvService), typeof(ImportProductFromCsvService));
            services.AddScoped(typeof(IProductFactory), typeof(ProductFactory));
        }
    }
}
