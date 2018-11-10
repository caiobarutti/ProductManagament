using ProductManagement.Domain.Products.Csv;

namespace ProductManagement.Domain.Products.Factory
{
    public class ProductFactory : IProductFactory
    {
        public Product Create(ProductCsv productCsv)
        {
            var key = PreventNoIndex(productCsv.Key);
            var articleCode = PreventNoIndex(productCsv.ArtikleCode);
            var colorCode = PreventNoIndex(productCsv.ColorCode);
            var description = PreventNoIndex(productCsv.Description);
            var price = productCsv.Price;
            var discountPrice = productCsv.DiscountPrice;
            var deliveredIn = PreventNoIndex(productCsv.DeliveredIn);
            var category = PreventNoIndex(productCsv.Q1);
            var size = productCsv.Size;
            var color = PreventNoIndex(productCsv.Color);

            return new Product(key, articleCode, colorCode, description, price, discountPrice, deliveredIn, category, size, color);
        }

        public string PreventNoIndex(string element)
        {
            return element.ToUpper() == "NOINDEX" ? string.Empty : element;
        }
    }
}