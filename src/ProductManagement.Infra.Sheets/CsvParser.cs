using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;
using ProductManagement.Domain;

namespace ProductManagement.Infra.Sheets
{
    public class CsvParser : ICsvParser
    {
        public List<ProductCsv> Parse(string csvString) 
        {
            var csvParserOptions = new CsvParserOptions(true, ',');
            var csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });

            var csvParser = new CsvParser<ProductCsv>(csvParserOptions, new CsvProductMapping());
            var records = csvParser.ReadFromString(csvReaderOptions, csvString);

            return records.Select(x => x.Result).ToList();
        }
    }
}
