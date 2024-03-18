using System.ComponentModel.DataAnnotations;

namespace StockProject.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public int Quantity { get; set; }
        public int TotalAmount { get; set; }

        public Guid ProviderId { get; set; }
        public Provider Provider { get; set; }
        public virtual ICollection<OrderDetails> OrderProducts { get; set; } /*= new HashSet<ProductOrder>();*/

    }
}
