using ProductManagement.Domain.Products;
using ProductManagement.Domain.Products.Repositories;
using ProductManagement.Infra.Database._base;

namespace ProductManagement.Infra.Database.Repositories
{
    public class ProductJsonRepository : JsonRepositoryBase<Product>, IProductJsonRepository
    {
        public ProductJsonRepository() : base("Product")
        {
        }
    }
}