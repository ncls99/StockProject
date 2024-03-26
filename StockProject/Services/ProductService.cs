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

        public async Task<Product> GetProductById(int id)
        {
            return await context.Product.FindAsync(id);
        }

        public bool Save(Product product)
        { 
            context.Product.Add(product);
            var validateSavedChanges = context.SaveChanges();

            return validateSavedChanges > 0;
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
        Task<Product> GetProductById(int id);
        bool Save(Product product);
        Task Update(Guid productId, Product product);
        Task Delete(Guid productId);
    }
}
