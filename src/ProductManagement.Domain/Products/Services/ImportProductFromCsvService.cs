using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductManagement.Domain.Products.Csv;
using ProductManagement.Domain.Products.Factory;
using ProductManagement.Domain.Products.Repositories;

namespace ProductManagement.Domain.Products.Services
{
    public class ImportProductFromCsvService : IImportProductFromCsvService
    {
        private readonly ICsvParser _csvParser;
        private readonly IProductFactory _productFactory;
        private readonly IProductRepository _productRepository;
        private readonly IProductJsonRepository _productJsonRepository;

        public ImportProductFromCsvService(ICsvParser csvParser, 
            IProductFactory productFactory,
            IProductRepository productRepository,
            IProductJsonRepository productJsonRepository)
        {
            _csvParser = csvParser;
            _productFactory = productFactory;
            _productRepository = productRepository;
            _productJsonRepository = productJsonRepository;
        }

        public void Import(string csv) 
        {
            var productsCsv = _csvParser.Parse(csv);
            var products = productsCsv.Select(productCsv => _productFactory.Create(productCsv));

            _productRepository.SaveAll(products);
            _productJsonRepository.SaveAll(products);
        }
    }
}