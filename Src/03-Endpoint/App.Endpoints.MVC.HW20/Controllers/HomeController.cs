using App.Endpoints.MVC.HW20.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Endpoints.MVC.HW20.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
