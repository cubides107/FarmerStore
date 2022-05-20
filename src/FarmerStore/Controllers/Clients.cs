using Microsoft.AspNetCore.Mvc;

namespace FarmerStore.Controllers
{
    public class Clients : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
