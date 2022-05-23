using FarmerStore.Models;
using FarmerStore.Models.Clients;

namespace FarmerStore.Services
{
    public class UsersServices
    {
        private IRepository repository;

        public UsersServices(IRepository repository)
        {
            this.repository = repository;
        }

        ///Registra un nuevo cliente
        public async Task Register(ClientsViewModel viewModel)
        {

            //Verificar que el usuario no este registrado
            if (!repository.Exists<User>(x => x.DocumentId == viewModel.DocumentId))
            {
                var client = User.Build(viewModel.Name, viewModel.LastName, viewModel.DocumentId);

                await this.repository.Save<User>(client);
                await this.repository.Commit();
            }

        }

        public async Task<string> Login(string email, string password)
        {
            User user;
            if (repository.Exists<User>(x => x.Email == email) is false)
                throw new Exception("El Usuario no se encuentra registrado");

            user = await repository.Get<User>(x => x.Email == email);

            if (user.Password == password)
                throw new Exception("Contraseña Incorrecta");

            return email;
        }
    }
}
