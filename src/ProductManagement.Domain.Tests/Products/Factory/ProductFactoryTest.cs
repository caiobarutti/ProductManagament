using ProductManagement.Domain.Products.Csv;
using ProductManagement.Domain.Products.Factory;
using ProductManagement.Domain.Tests.Helpers.Builders;
using Xunit;

namespace ProductManagement.Domain.Tests.Products.Factory
{
    public class ProductFactoryTest
    {
        private ProductFactory _productFactory;
        private ProductCsv _productCsv;

        public ProductFactoryTest()
        {
            _productCsv = ProductCsvBuilder.AProductCsv().Build();

            _productFactory = new ProductFactory();
        }

        [Fact] 
        public void ShouldCreateAProduct() 
        {
            var product = _productFactory.Create(_productCsv);

            Assert.Equal(_productCsv.Key, product.Key);
            Assert.Equal(_productCsv.ArtikleCode, product.ArticleCode);
            Assert.Equal(_productCsv.ColorCode, product.ColorCode);
            Assert.Equal(_productCsv.Description, product.Description);
            Assert.Equal(_productCsv.Price, product.Price);
            Assert.Equal(_productCsv.DiscountPrice, product.DiscountPrice);
            Assert.Equal(_productCsv.DeliveredIn, product.DeliveredIn);
            Assert.Equal(_productCsv.Q1, product.Category);
            Assert.Equal(_productCsv.Size, product.Size);
            Assert.Equal(_productCsv.Color, product.Color);
        }

        [Fact]
        public void ShouldPreventNoIndexForKeyAttribute()
        {
            var key = "NOINDEX";
            _productCsv = ProductCsvBuilder.AProductCsv().WithKey(key).Build();

            var product = _productFactory.Create(_productCsv);

            Assert.Empty(product.Key);
        }

        [Fact]
        public void ShouldPreventNoIndexForArticleCodeAttribute()
        {
            var articleCode = "NOINDEX";
            _productCsv = ProductCsvBuilder.AProductCsv().WithArtikleCode(articleCode).Build();

            var product = _productFactory.Create(_productCsv);

            Assert.Empty(product.ArticleCode);
        }

        [Fact]
        public void ShouldPreventNoIndexForColorCodeAttribute()
        {
            var colorCode = "NOINDEX";
            _productCsv = ProductCsvBuilder.AProductCsv().WithColorCode(colorCode).Build();

            var product = _productFactory.Create(_productCsv);

            Assert.Empty(product.ColorCode);
        }

        [Fact]
        public void ShouldPreventNoIndexForDescriptionAttribute()
        {
            var description = "NOINDEX";
            _productCsv = ProductCsvBuilder.AProductCsv().WithDescription(description).Build();

            var product = _productFactory.Create(_productCsv);

            Assert.Empty(product.Description);
        }

        [Fact]
        public void ShouldPreventNoIndexForDeliveredInAttribute()
        {
            var deliveredIn = "NOINDEX";
            _productCsv = ProductCsvBuilder.AProductCsv().WithDeliveredIn(deliveredIn).Build();

            var product = _productFactory.Create(_productCsv);

            Assert.Empty(product.DeliveredIn);
        }

        [Fact]
        public void ShouldPreventNoIndexForCategoryAttribute()
        {
            var q1 = "NOINDEX";
            _productCsv = ProductCsvBuilder.AProductCsv().WithQ1(q1).Build();

            var product = _productFactory.Create(_productCsv);

            Assert.Empty(product.Category);
        }

        [Fact]
        public void ShouldPreventNoIndexForColorAttribute()
        {
            var color = "NOINDEX";
            _productCsv = ProductCsvBuilder.AProductCsv().WithColor(color).Build();

            var product = _productFactory.Create(_productCsv);

            Assert.Empty(product.Color);
        }
    }
}