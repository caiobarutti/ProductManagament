using System.Linq;
using ProductManagement.Domain.Products.Csv;
using Xunit;

namespace ProductManagement.Infra.Sheets.Tests
{
    public class CsvParserTest
    {
        private readonly CsvParser _csvParser;

        public CsvParserTest()
        {
            _csvParser = new CsvParser();
        }

        [Fact]
        public void ShouldParseStringToProductCsv()
        {
            var productCsvLineExpected = new ProductCsv("2800104", "2", "broek", "Gaastra", 8m, 0m, "1-3 werkdagen", "baby", 104, "grijs");

            var result = _csvParser.Parse(@"Key,ArtikelCode,ColorCode,Description,Price,DiscountPrice,DeliveredIn,Q1,Size,Color
                            2800104,2,broek,Gaastra,8,0,1-3 werkdagen,baby,104,grijs");

            Assert.Equal(productCsvLineExpected, result.First());
        }

        [Fact]
        public void ShouldReturnAnEmptyListWhenTheCsvIsEmpty()
        {
            var result = _csvParser.Parse(string.Empty);

            Assert.Empty(result);
        }

        [Fact]
        public void ShouldReturnAnEmptyListWhenTheCsvContainsOnlyTheHeaders()
        {
            var result = _csvParser.Parse("Key,ArtikelCode,ColorCode,Description,Price,DiscountPrice,DeliveredIn,Q1,Size,Color");

            Assert.Empty(result);
        }
    }
}