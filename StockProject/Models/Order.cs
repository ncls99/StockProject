using System.ComponentModel.DataAnnotations;

namespace StockProject.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public int TotalAmount { get; set; }
        public virtual ICollection<ProductOrder> OrderProducts { get; set; } = new HashSet<ProductOrder>();

    }
}
