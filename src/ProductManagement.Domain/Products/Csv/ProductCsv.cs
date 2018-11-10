using ProductManagement.Domain._base;

namespace ProductManagement.Domain.Products.Csv
{
    public class ProductCsv : ValueObject<ProductCsv>
    {
        public string Key { get; set; }
        public string ArtikleCode { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string DeliveredIn { get; set; }
        public string Q1 { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }

        public ProductCsv() { }

        public ProductCsv(string key, string artikleCode, string colorCode, string description, decimal price, decimal discountPrice,
            string deliveredIn, string q1, int size, string color)
        {
            Key = key;
            ArtikleCode = artikleCode;
            ColorCode = colorCode;
            Description = description;
            Price = price;
            DiscountPrice = discountPrice;
            DeliveredIn = deliveredIn;
            Q1 = q1;
            Size = size;
            Color = color;
        }

        protected override bool AllAttributesAreEqual(ProductCsv otherValueObject) 
        {
            return Key == otherValueObject.Key && ArtikleCode == otherValueObject.ArtikleCode && ColorCode == otherValueObject.ColorCode
                && Description == otherValueObject.Description && Price == otherValueObject.Price && DiscountPrice == otherValueObject.DiscountPrice
                && DeliveredIn == otherValueObject.DeliveredIn && Q1 == otherValueObject.Q1 && Size == otherValueObject.Size && Color == otherValueObject.Color;
        }

        protected override int HashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}