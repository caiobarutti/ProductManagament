using ProductManagement.Domain._base;

namespace ProductManagement.Domain.Products
{
    public class Product : Entity
    {
        public string Key { get; protected set; }
        public string ArticleCode { get; protected set; }
        public string ColorCode { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }
        public decimal DiscountPrice { get; protected set; }
        public string DeliveredIn { get; protected set; }
        public string Category { get; protected set; }
        public int Size { get; protected set; }
        public string Color { get; protected set; }

        protected Product() { }

        public Product(string key, string articleCode, string colorCode, string description, decimal price, decimal discountPrice,
            string deliveredIn, string category, int size, string color)
        {
            Key = key;
            ArticleCode = articleCode;
            ColorCode = colorCode;
            Description = description;
            Price = price;
            DiscountPrice = discountPrice;
            DeliveredIn = deliveredIn;
            Category = category;
            Size = size;
            Color = color;
        }
    }
}