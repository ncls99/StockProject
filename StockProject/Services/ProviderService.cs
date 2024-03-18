using StockProject.Database_Context;
using StockProject.Models;

namespace StockProject.Services
{
    public class ProviderService : IProviderService
    {
        DataBaseContext context;
        public ProviderService(DataBaseContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Provider> Get()
        {
            return context.Provider;
        }

        public async Task Save(Provider provider)
        {
            context.Add(provider);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid providerId, Provider provider)
        {
            var providerActual = context.Provider.Find(providerId);
            if (providerActual != null)
            {
                providerActual.Name = provider.Name;
                providerActual.PhoneNumber = provider.PhoneNumber;
                provider.Products = providerActual.Products;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid providerId)
        {
            var providerActual = context.Provider.Find(providerId);
            if (providerActual != null)
            {
                context.Remove(providerActual);
                await context.SaveChangesAsync();
            }

        }
    }
    public interface IProviderService
    {
        IEnumerable<Provider> Get();
        Task Save(Provider provider);
        Task Update(Guid providerId, Provider provider);
        Task Delete(Guid providerId);

    }
}
