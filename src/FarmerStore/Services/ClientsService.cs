using FarmerStore.Models;
using FarmerStore.Models.Clients;

namespace FarmerStore.Services
{
    public class ClientsService
    {
        private IRepository repository;

        public ClientsService(IRepository repository)
        {
            this.repository = repository;
        }

        ///Registra un nuevo cliente
        public async Task Register(ClientsViewModel viewModel)
        {

            //Verificar que el usuario no este registrado
            if (!repository.Exists<Client>(x => x.DocumentId == viewModel.DocumentId))
            {
                var client = Client.Build(viewModel.Name, viewModel.LastName, viewModel.DocumentId);

                await this.repository.Save<Client>(client);
                await this.repository.Commit();
            }

        }
    }
}
