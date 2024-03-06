using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockProject.Models
{
    public class Product
    {
        [Key][Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [Required]
        public Guid ProviderID { get; set; }
        public Provider Provider { get; set; }
        public ICollection<VentaProducto> SaleProducts { get; set; } = new HashSet<VentaProducto>();
    }
}
