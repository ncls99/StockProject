using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockProject.Models
{
    public class Sale
    {
        [Key]
        [Required]
        public int SaleId { get; set; }
        public DateTime DateSale { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int TotalAmount { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<VentaProducto> SaleProducts { get; set; } = new HashSet<VentaProducto>();

    }
}
