using TinyCsvParser.Mapping;

namespace ProductManagement.Infra.Sheets {
    public class CsvProductMapping : CsvMapping<ProductCsv> {
        public CsvProductMapping () : base () 
        {
            MapProperty(0, x => x.Key);
            MapProperty(1, x => x.ArtikleCode);
            MapProperty(2, x => x.ColorCode);
            MapProperty(3, x => x.Description);
            MapProperty(4, x => x.Price);
            MapProperty(5, x => x.DiscountPrice);
            MapProperty(6, x => x.DeliveredIn);
            MapProperty(7, x => x.Q1);
            MapProperty(8, x => x.Size);
            MapProperty(9, x => x.Color);
        }
    }
}