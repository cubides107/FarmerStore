using FarmerStore.Models.Clients;
using FarmerStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmerStore.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientsService service;

        public ClientsController(ClientsService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(ClientsViewModel viewModel)
        {

            service.Register(viewModel);

            return Redirect("Index");
        }
    }
}
