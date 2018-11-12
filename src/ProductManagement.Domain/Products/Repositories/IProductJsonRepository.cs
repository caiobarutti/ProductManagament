using System.Collections.Generic;
using ProductManagement.Domain.Products.Csv;
using ProductManagement.Domain._base;

namespace ProductManagement.Domain.Products.Repositories
{
    public interface IProductJsonRepository : IJsonRepositoryBase<Product>
    {
    }
}