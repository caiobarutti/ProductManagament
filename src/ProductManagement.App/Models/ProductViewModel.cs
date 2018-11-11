using ProductManagement.Domain.Products;

namespace ProductManagement.App.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }
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

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Key = product.Key;
            ArticleCode = product.ArticleCode;
            ColorCode = product.ColorCode;
            Description = product.Description;
            Price = product.Price;
            DiscountPrice = product.DiscountPrice;
            DeliveredIn = product.DeliveredIn;
            Category = product.Category;
            Size = product.Size;
            Color = product.Color;
        }
    }
}