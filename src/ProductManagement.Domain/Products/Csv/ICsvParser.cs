using System.Collections.Generic;
using ProductManagement.Domain.Products.Csv;

namespace ProductManagement.Domain.Products.Csv
{
    public interface ICsvParser
    {
        List<ProductCsv> Parse(string csvString);
    }
}
