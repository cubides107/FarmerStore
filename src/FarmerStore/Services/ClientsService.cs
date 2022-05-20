using FarmerStore.Models;

namespace FarmerStore.Services
{
    public class ClientsService
    {
        private IRepository repository;

        public ClientsService(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
