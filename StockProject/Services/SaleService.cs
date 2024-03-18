using StockProject.Database_Context;
using StockProject.Models;

namespace StockProject.Services
{
    public class SaleService : ISaleService
    {
        DataBaseContext context;

        public SaleService(DataBaseContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Sale> Get()
        {
            return context.Sale;
        }

        public async Task Save(Sale sale)
        { 
            context.Add(sale);
            await context.SaveChangesAsync();
        }

        public async Task Update(int saleId, Sale sale)
        { 
            var saleActual = context.Sale.Find(saleId);
            if (saleActual == null) 
            {
                saleActual.DateSale = sale.DateSale;
                saleActual.TotalAmount = sale.TotalAmount;
                saleActual.SaleProducts = sale.SaleProducts;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int saleId)
        {
            var saleActual = context.Sale.Find(saleId);
            if (saleActual == null)
            { 
                context.Remove(saleActual);
                await context.SaveChangesAsync();
            }

        }
    }

    public interface ISaleService
    {
        IEnumerable<Sale> Get();
        Task Save(Sale sale);
        Task Update(int saleId, Sale sale);
        Task Delete(int saleId);
    }
}
