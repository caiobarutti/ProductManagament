using System;
using ProductManagement.Domain.Products.Csv;
using ProductManagement.Domain.Products.Factory;
using ProductManagement.Domain.Products.Repository;

namespace ProductManagement.Domain.Products.Services
{
    public class ImportProductFromCsvService : IImportProductFromCsvService
    {
        private readonly ICsvParser _csvParser;
        private readonly IProductFactory _productFactory;
        private readonly IProductRepository _productRepository;

        public ImportProductFromCsvService(ICsvParser csvParser, 
            IProductFactory productFactory,
            IProductRepository productRepository)
        {
            _csvParser = csvParser;
            _productFactory = productFactory;
            _productRepository = productRepository;
        }

        public void Import(string csv) 
        {
            var productsCsv = _csvParser.Parse(csv);

            foreach(var productCsv in productsCsv)
            {
                var product = _productFactory.Create(productCsv);

                _productRepository.Save(product);
            }
        }
    }
}