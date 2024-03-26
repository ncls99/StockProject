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

        public async Task<Provider> GetProviderById(Guid id)
        {
            return await context.Provider.FindAsync(id);
        }

        public bool Save(Provider provider)
        {
            context.Provider.Add(provider);
            var validateSavedChanges = context.SaveChanges();
            return validateSavedChanges > 0;
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
        Task<Provider> GetProviderById(Guid id);
        bool Save(Provider provider);
        Task Update(Guid providerId, Provider provider);
        Task Delete(Guid providerId);

    }
}
