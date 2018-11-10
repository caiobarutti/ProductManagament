using ProductManagement.Domain.Products.Csv;
using Xunit;

namespace ProductManagement.Domain.Tests.Products.Csv
{
    public class ProductCsvTest
    {
        private string _key = "1";
        private string _artikleCode = "d21d";
        private string _colorCode = "jeans";
        private string _description = "vandf";
        private decimal _price = 10m;
        private decimal _discountPrice = 15m;
        private string _deliveredId = "2 business days";
        private string _q1 = "boy";
        private int _size = 54;
        private string _color = "blue";

        [Fact]
        public void ShouldCreateAProductCsv()
        {
            var product = new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredId, _q1, _size, _color);

            Assert.Equal(_key, product.Key);
            Assert.Equal(_artikleCode, product.ArtikleCode);
            Assert.Equal(_colorCode, product.ColorCode);
            Assert.Equal(_description, product.Description);
            Assert.Equal(_price, product.Price);
            Assert.Equal(_discountPrice, product.DiscountPrice);
            Assert.Equal(_deliveredId, product.DeliveredIn);
            Assert.Equal(_q1, product.Q1);
            Assert.Equal(_size, product.Size);
            Assert.Equal(_color, product.Color);
        }

        [Fact]
        public void ShouldCreateAProductCsvWhitoutKey()
        {
            _key = string.Empty;
            var product = new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredId, _q1, _size, _color);

            Assert.Empty(product.Key);
        }

        [Fact]
        public void ShouldCreateAProductCsvWhitoutArtikleCode()
        {
            _artikleCode = string.Empty;
            var product = new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredId, _q1, _size, _color);

            Assert.Empty(product.ArtikleCode);
        }

        [Fact]
        public void ShouldCreateAProductCsvWhitoutArticleColorCode()
        {
            _colorCode = string.Empty;
            var product = new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredId, _q1, _size, _color);

            Assert.Empty(product.ColorCode);
        }

        [Fact]
        public void ShouldCreateAProductCsvWhitoutDescription()
        {
            _description = string.Empty;
            var product = new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredId, _q1, _size, _color);

            Assert.Empty(product.Description);
        }

        [Fact]
        public void ShouldCreateAProductCsvWhitoutPrice()
        {
            _price = 0m;
            var product = new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredId, _q1, _size, _color);

            Assert.Equal(0m, product.Price);
        }

        [Fact]
        public void ShouldCreateAProductCsvWhitoutDiscountPrice()
        {
            _discountPrice = 0m;
            var product = new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredId, _q1, _size, _color);

            Assert.Equal(0m, product.DiscountPrice);
        }

        [Fact]
        public void ShouldCreateAProductCsvWhitoutDeliveredIn()
        {
            _deliveredId = string.Empty;
            var product = new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredId, _q1, _size, _color);

            Assert.Empty(product.DeliveredIn);
        }

        [Fact]
        public void ShouldCreateAProductCsvWhitoutQ1()
        {
            _q1 = string.Empty;
            var product = new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredId, _q1, _size, _color);

            Assert.Empty(product.Q1);
        }

        [Fact]
        public void ShouldCreateAProductCsvWhitoutSize()
        {
            _size = 0;
            var product = new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredId, _q1, _size, _color);

            Assert.Equal(0, product.Size);
        }

        [Fact]
        public void ShouldCreateAProductCsvWhitoutColor()
        {
            _color = string.Empty;
            var product = new ProductCsv(_key, _artikleCode, _colorCode, _description, _price, _discountPrice, _deliveredId, _q1, _size, _color);

            Assert.Empty(product.Color);
        }
    }
}