using ProductManagement.Domain;
using ProductManagement.Domain.Products;
using ProductManagement.Domain.Products.Repository;
using ProductManagement.Infra.Database._base;

namespace ProductManagement.Infra.Database.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        
    }
}