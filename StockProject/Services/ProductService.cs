using StockProject.Database_Context;
using StockProject.Models;

namespace StockProject.Services
{
    public class ProductService : IProductService
    {
        DataBaseContext context;
        public ProductService(DataBaseContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Product> Get()
        {
            return context.Product;
        }

        public async Task Save(Product product)
        { 
            context.Add(product);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid productId, Product product)
        { 
            var productActual = context.Product.Find(productId);
            if (productActual != null)
            {
                productActual.ProductName = product.ProductName;
                productActual.ProductPrice = product.ProductPrice;  

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid productId)
        {
            var productActual = context.Product.Find(productId);
            if (productActual != null)
            {
                context.Remove(productActual);
                await context.SaveChangesAsync();
            }
        }

    }
    public interface IProductService
    {
        IEnumerable<Product> Get();
        Task Save(Product product);
        Task Update(Guid productId, Product product);
        Task Delete(Guid productId);
    }
}
