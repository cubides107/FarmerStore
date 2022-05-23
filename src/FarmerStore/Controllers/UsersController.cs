using FarmerStore.Models.Clients;
using FarmerStore.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FarmerStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersServices service;

        public UsersController(UsersServices service)
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


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            List<Claim> claims;
            string mailAux;

            mailAux = await service.Login(email, password);

            claims = new()
            {
                new Claim(ClaimTypes.Email, mailAux)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }
    }
}
