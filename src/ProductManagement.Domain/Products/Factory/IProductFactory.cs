using ProductManagement.Domain.Products.Csv;

namespace ProductManagement.Domain.Products.Factory
{
    public interface IProductFactory
    {
        Product Create(ProductCsv productCsv);
    }
}