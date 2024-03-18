using System.ComponentModel.DataAnnotations;

namespace StockProject.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
