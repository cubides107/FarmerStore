using FarmerStore.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace FarmerStore.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        /// <summary>
        /// Metodo de Prueba para registrar un producto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", product);   
            }

            TempData["Message"] = "Producto creado";
            return Redirect("Index");
        }
    }
}
