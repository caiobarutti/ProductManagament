namespace ProductManagement.Domain
{
    public class Product
    {
        public string Key { get; set; }
        public string ArticleCode { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string DeliveredIn { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}