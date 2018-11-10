using System.Collections.Generic;

namespace ProductManagement.Infra.Sheets
{
    public interface ICsvParser
    {
        List<ProductCsv> Parse(string csvString);
    }
}
