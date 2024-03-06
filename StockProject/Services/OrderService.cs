using Microsoft.EntityFrameworkCore;
using StockProject.Database_Context;
using StockProject.Models;

namespace StockProject.Services
{
    public class OrderService : IOrderService
    {
        DataBaseContext context;
        public OrderService(DataBaseContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Order> Get()
        {
            return context.Orders;
        }

        public async Task Save(Order order)
        { 
            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            var orderActual = context.Orders.Find(order.OrderId);
            if (orderActual != null)
            { 
                orderActual.OrderDate = order.OrderDate;
                orderActual.TotalAmount = order.TotalAmount;
                orderActual.Provider.OrderProducts = order.Provider.OrderProducts;
            }

        }

        public async Task Delete(int orderId)
        {
            var orderActual = context.Orders.Find(orderId);
            if (orderActual != null)
            { 
                context.Remove(orderActual);
                await context.SaveChangesAsync();
            }
        }


        public void ProcesarNuevaOrden(Order nuevaOrden)
        {
            var producto = context.Productos.Find(nuevaOrden.ProductId);

            if (producto != null)
            {
                producto.Quantity += nuevaOrden.Quantity;
                context.SaveChanges();
            }
        }
    }
        public interface IOrderService
    {
        IEnumerable<Order> Get();
        Task Save(Order order);
        Task Update(Order order);
        Task Delete(int orderId);
        void ProcesarNuevaOrden(Order nuevaOrden);
    }
}
