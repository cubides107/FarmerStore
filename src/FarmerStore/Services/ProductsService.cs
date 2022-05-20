using FarmerStore.Models;

namespace FarmerStore.Services
{
    public class ProductsService
    {
        private IRepository repository;

        public ProductsService(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
