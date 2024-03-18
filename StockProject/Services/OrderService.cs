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
            return context.Order;
        }

        public async Task Save(Order order)
        { 
            context.Order.Add(order);
            await context.SaveChangesAsync();
        }

        public async Task Update(int orderId, Order order)
        {
            var orderActual = context.Order.Find(orderId);
            if (orderActual != null)
            { 
                orderActual.OrderDate = order.OrderDate;
                orderActual.TotalAmount = order.TotalAmount;
                orderActual.OrderProducts = order.OrderProducts;
            }

        }

        public async Task Delete(int orderId)
        {
            var orderActual = context.Order.Find(orderId);
            if (orderActual != null)
            { 
                context.Remove(orderActual);
                await context.SaveChangesAsync();
            }
        }
    }
        public interface IOrderService
    {
        IEnumerable<Order> Get();
        Task Save(Order order);
        Task Update(int orderId, Order order);
        Task Delete(int orderId);
    }
}
