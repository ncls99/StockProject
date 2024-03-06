using Microsoft.EntityFrameworkCore;
using StockProject.Models;

namespace StockProject.Database_Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Productos { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<VentaProducto> ventaProductos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(product =>
            {
                product.ToTable("Product");
                product.HasOne(p => p.Provider)
                .WithMany(pv => pv.Products)
                .HasForeignKey(p => p.ProviderID);
            });

            modelBuilder.Entity<Sale>(sale =>
            {
                sale.ToTable("Sale");
                sale.HasMany(p => p.SaleProducts)
                .WithOne().IsRequired();
            });

            modelBuilder.Entity<Sale>(sale =>
            {
                sale.HasMany(v => v.SaleProducts)
                .WithOne(vp => vp.Sale)
                .HasForeignKey(vp => vp.SaleId);
            });

            modelBuilder.Entity<ProductOrder>(p =>
            { 
                p.HasOne(po => po.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(po => po.OrderId);
            });
            modelBuilder.Entity<ProductOrder>(p =>
            { 
                p.HasOne(po => po.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(po => po.ProductId);
            });

        }
    }
}
