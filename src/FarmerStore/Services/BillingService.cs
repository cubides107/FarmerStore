using FarmerStore.Models;

namespace FarmerStore.Services
{
    public class BillingService
    {
        private IRepository repository;

        public BillingService(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
