using Microsoft.AspNetCore.Mvc;

namespace FarmerStore.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
