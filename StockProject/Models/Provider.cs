using System.ComponentModel.DataAnnotations;

namespace StockProject.Models
{
    public class Provider
    {
        [MaxLength(30)]
        public string Name { get; set; }
        [Key]
        [Required]
        public Guid ProviderId { get; set; }    
        public string PhoneNumber { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ProductProvider> productProviders { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
