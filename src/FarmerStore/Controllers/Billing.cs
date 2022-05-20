using Microsoft.AspNetCore.Mvc;

namespace FarmerStore.Controllers
{
    public class Billing : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
