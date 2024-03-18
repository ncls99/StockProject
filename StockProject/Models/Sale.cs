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
        public int TotalAmount { get; set; }
        public virtual ICollection<SaleDetails> SaleProducts { get; set; } /*= new HashSet<VentaProducto>();*/

    }
}
