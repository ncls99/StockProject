namespace StockProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider{ get; set; }
        public int Quantity { get; set; }
        public int TotalAmount { get; set; }
        public virtual ICollection<ProductOrder> OrderProducts { get; set; } = new HashSet<ProductOrder>();

    }
}
