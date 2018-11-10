using System;
using System.Linq;
using ProductManagement.Domain.Products.Csv;
using ProductManagement.Infra.Sheets;
using Xunit;

namespace ProductManagement.Infra.Sheets.Tests
{
    public class CsvParserTest
    {
        [Fact]
        public void ShouldParseStringToProductCsv()
        {
            var csvParser = new ProductManagement.Infra.Sheets.CsvParser();
            var productCsvLineExpected = new ProductCsv("2800104", "2", "broek", "Gaastra", 8m, 0m, "1-3 werkdagen", "baby", 104, "grijs");

            var result = csvParser.Parse(@"Key,ArtikelCode,ColorCode,Description,Price,DiscountPrice,DeliveredIn,Q1,Size,Color
                            2800104,2,broek,Gaastra,8,0,1-3 werkdagen,baby,104,grijs");

            Assert.Equal(productCsvLineExpected, result.First());
        }

        [Fact]
        public void ShouldReturnAnEmptyListWhenTheCsvIsEmpty()
        {
            var csvParser = new ProductManagement.Infra.Sheets.CsvParser();

            var result = csvParser.Parse(string.Empty);

            Assert.Empty(result);
        }

        [Fact]
        public void ShouldReturnAnEmptyListWhenTheCsvContainsOnlyTheHeaders()
        {
            var csvParser = new ProductManagement.Infra.Sheets.CsvParser();

            var result = csvParser.Parse("Key,ArtikelCode,ColorCode,Description,Price,DiscountPrice,DeliveredIn,Q1,Size,Color");

            Assert.Empty(result);
        }
    }
}