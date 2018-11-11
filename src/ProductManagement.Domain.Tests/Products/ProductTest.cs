using ExpectedObjects;
using ProductManagement.Domain.Products;
using Xunit;

namespace ProductManagement.Domain.Tests.Products
{
    public class ProductTest
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

        [Fact]
        public void ShouldCreateAProduct()
        {
            var productExpected = new
            {
                Key = _key,
                ArticleCode = _articleCode,
                ColorCode = _colorCode,
                Description = _description,
                Price = _price,
                DiscountPrice = _discountPrice,
                DeliveredIn = _deliveredIn,
                Category = _category,
                Size = _size,
                Color = _color,
            };

            var product = new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);

            productExpected.ToExpectedObject().Matches(product);
        }

        [Fact]
        public void ShouldCreateAProductWhitoutKey()
        {
            _key = string.Empty;
            var product = new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);

            Assert.Empty(product.Key);
        }

        [Fact]
        public void ShouldCreateAProductWhitoutArticleCode()
        {
            _articleCode = string.Empty;
            var product = new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);

            Assert.Empty(product.ArticleCode);
        }

        [Fact]
        public void ShouldCreateAProductWhitoutArticleColorCode()
        {
            _colorCode = string.Empty;
            var product = new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);

            Assert.Empty(product.ColorCode);
        }

        [Fact]
        public void ShouldCreateAProductWhitoutDescription()
        {
            _description = string.Empty;
            var product = new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);

            Assert.Empty(product.Description);
        }

        [Fact]
        public void ShouldCreateAProductWhitoutPrice()
        {
            _price = 0m;
            var product = new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);

            Assert.Equal(0m, product.Price);
        }

        [Fact]
        public void ShouldCreateAProductWhitoutDiscountPrice()
        {
            _discountPrice = 0m;
            var product = new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);

            Assert.Equal(0m, product.DiscountPrice);
        }

        [Fact]
        public void ShouldCreateAProductWhitoutDeliveredIn()
        {
            _deliveredIn = string.Empty;
            var product = new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);

            Assert.Empty(product.DeliveredIn);
        }

        [Fact]
        public void ShouldCreateAProductWhitoutCategory()
        {
            _category = string.Empty;
            var product = new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);

            Assert.Empty(product.Category);
        }

        [Fact]
        public void ShouldCreateAProductWhitoutSize()
        {
            _size = 0;
            var product = new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);

            Assert.Equal(0, product.Size);
        }

        [Fact]
        public void ShouldCreateAProductWhitoutColor()
        {
            _color = string.Empty;
            var product = new Product(_key, _articleCode, _colorCode, _description, _price, _discountPrice, _deliveredIn, _category, _size, _color);

            Assert.Empty(product.Color);
        }
    }
}