namespace StockProject.Models
{
    public class ProductProvider
    {
        public Guid ProviderId { get; set; }
        public Provider Provider { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } 
        public int Cost { get; set; }
    }
}
