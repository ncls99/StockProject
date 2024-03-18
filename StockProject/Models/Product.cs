using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockProject.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [Required]
        public Guid ProviderID { get; set; }
        public Provider Provider { get; set; }
        public ICollection<SaleDetails> SaleProducts { get; set; } /*= new HashSet<VentaProducto>();*/
        public ICollection<OrderDetails> OrderProducts { get; set; } /*= new HashSet<ProductOrder>();*/
        public ICollection<ProductProvider> productProviders { get; set; }
        public int UnitsInStock { get; set; }
    }
}
