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
            return context.Sales;
        }

        public async Task Save(Sale sale)
        { 
            context.Add(sale);
            await context.SaveChangesAsync();
        }

        public async Task Update(int saleId, Sale sale)
        { 
            var saleActual = context.Sales.Find(saleId);
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
            var saleActual = context.Sales.Find(saleId);
            if (saleActual == null)
            { 
                context.Remove(saleActual);
                await context.SaveChangesAsync();
            }

        }

        public void ProcesarNuevaSale(Sale nuevaSale)
        {
            var producto = context.Productos.Find(nuevaSale.ProductId);

            if (producto != null)
            {
                producto.Quantity += nuevaSale.Quantity;
                context.SaveChanges();
            }
        }
    }

    public interface ISaleService
    {
        IEnumerable<Sale> Get();
        Task Save(Sale sale);
        Task Update(int saleId, Sale sale);
        Task Delete(int saleId);

        void ProcesarNuevaSale(Sale nuevaSale);
    }
}
