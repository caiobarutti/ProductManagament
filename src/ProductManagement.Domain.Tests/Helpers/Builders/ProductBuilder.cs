using ProductManagement.Domain.Products;

namespace ProductManagement.Domain.Tests.Helpers.Builders
{
    public class ProductBuilder
    {
        private string _key = "1";
        private string _articleCode = "d21d";
        private string _colorCode = "jeans";
        private string _description = "vandf";
        private decimal _price = 10m;
        private decimal _discountPrice = 15m;
        private string _deliveredIn = "2 business days";
        private string _category = "boy";
        private int _size = 54;
        private string _color = "blue";

        public static ProductBuilder AProduct()
        {
            return new ProductBuilder();
        }

        public Product Build()
        {
            return new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);
        }
    }
}