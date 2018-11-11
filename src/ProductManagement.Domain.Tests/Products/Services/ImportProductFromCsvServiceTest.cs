using Xunit;
using ProductManagement.Domain.Products.Services;
using ProductManagement.Domain.Products.Csv;
using Moq;
using ProductManagement.Domain.Products.Factory;
using ProductManagement.Domain.Tests.Helpers.Builders;
using System.Collections.Generic;
using ProductManagement.Domain.Products.Repository;
using ProductManagement.Domain.Products;

namespace ProductManagement.Domain.Tests.Products.Services
{
    public class ImportProductFromCsvServiceTest
    {
        private readonly Mock<ICsvParser> _csvParser;
        private readonly Mock<IProductFactory> _productFactory;
        private readonly Mock<IProductRepository> _productRepository;
        private readonly ImportProductFromCsvService _importProductFromCsvService;
        private readonly string _csv;
        private ProductCsv _productCsv;
        private Product _product;

        public ImportProductFromCsvServiceTest()
        {
            _csv = @"Key,ArtikelCode,ColorCode,Description,Price,DiscountPrice,DeliveredIn,Q1,Size,Color
                            2800104,2,broek,Gaastra,8,0,1-3 werkdagen,baby,104,grijs";

            _csvParser = new Mock<ICsvParser>();
            _productFactory = new Mock<IProductFactory>();
            _productRepository = new Mock<IProductRepository>();

            _importProductFromCsvService = new ImportProductFromCsvService(_csvParser.Object, _productFactory.Object, _productRepository.Object);

            InitializeMocks();
        }

        private void InitializeMocks() 
        {
            _productCsv = ProductCsvBuilder.AProductCsv().Build();
            var productsCsv = new List<ProductCsv>() { _productCsv };
            _csvParser.Setup(x => x.Parse(_csv)).Returns(productsCsv);
            _product = ProductBuilder.AProduct().Build();
            
            _productFactory.Setup(x => x.Create(_productCsv)).Returns(_product);
        }

        [Fact]
        public void ShouldParseTheCsvToProductCsv()
        {
            _importProductFromCsvService.Import(_csv);

            _csvParser.Verify(parser => parser.Parse(_csv), Times.Once);
        }

        [Fact]
        public void ShouldCreateTheProductUsingTheProductFactory()
        {
            _importProductFromCsvService.Import(_csv);

            _productFactory.Verify(x => x.Create(_productCsv), Times.Once);
        }

        [Fact]
        public void ShouldSaveTheProduct() 
        {
            _importProductFromCsvService.Import(_csv);

            _productRepository.Verify(x => x.Save(_product), Times.Once);
        }
    }
}