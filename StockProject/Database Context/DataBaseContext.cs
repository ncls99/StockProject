
using Microsoft.EntityFrameworkCore;
using StockProject.Models;

namespace StockProject.Database_Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<SaleDetails> SaleDetails { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ProductProvider> ProductProvider { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(product =>
            {
                product.HasOne(p => p.Provider)
                .WithMany(pv => pv.Products)
                .HasForeignKey(p => p.ProviderID);
            });

            modelBuilder.Entity<Order>(order =>
            {
                order.HasOne(o => o.Provider)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProviderId);
            });

            //Relations for the third table ProductProvider
            //Primary Key
            modelBuilder.Entity<ProductProvider>(pp =>
            {
                pp.HasKey(pp => new { pp.ProductId, pp.ProviderId });
            });

            //Relation M:1 with Provider entity
            modelBuilder.Entity<ProductProvider>(pp =>
            {
                pp.HasOne(p => p.Provider)
                .WithMany(p => p.productProviders)
                .HasForeignKey(pp => pp.ProviderId);
            });

            //Relation M:1 with Provider entity
            modelBuilder.Entity<ProductProvider>(pp =>
            {
                pp.HasOne(p => p.Product)
                .WithMany(p => p.productProviders)
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            });


            //Relations for the third table OrderDetails
            //Primary Key
            modelBuilder.Entity<OrderDetails>(po =>
                {
                    po.HasKey(op => new { op.OrderId, op.ProductId });
                });

            //Relation M:1 with Order entity
            modelBuilder.Entity<OrderDetails>(po =>
                {
                    po.HasOne(op => op.Order)
                    .WithMany(o => o.OrderProducts)
                    .HasForeignKey(op => op.OrderId);
                });

            //Relation M:1 with Product entity

            modelBuilder.Entity<OrderDetails>(po =>
            {
                po.HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            //Relations for the third table SaleDetails
            //Primary Key
            modelBuilder.Entity<SaleDetails>(vp =>
                {
                    vp.HasKey(sp => new { sp.SaleId, sp.ProductId });
                });

            //Relation M:1 with Sale entity
            modelBuilder.Entity<SaleDetails>(vp =>
            {
                vp.HasOne(sp => sp.Sale)
                .WithMany(s => s.SaleProducts)
                .HasForeignKey(sp => sp.SaleId);
            });

            //Relation M:1 with Product entity
            modelBuilder.Entity<SaleDetails>(vp =>
            {
                vp.HasOne(sp => sp.Product)
                .WithMany(p => p.SaleProducts)
                .HasForeignKey(sp => sp.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            });
        }
    }
}
