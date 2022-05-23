using FarmerStore.Models;
using FarmerStore.Models.Clients;
using FarmerStore.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FarmerStore.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}