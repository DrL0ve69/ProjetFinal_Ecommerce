using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetFinal_Ecommerce.Models;
using ProjetFinal_Ecommerce.ViewModels;

namespace ProjetFinal_Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ViewModels.ErrorViewModel 
            {
                Titre = "Erreur",
                Message = "Une erreur s'est produite.",
                Trace = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Action = $"{ControllerContext.ActionDescriptor.ControllerName}/{ControllerContext.ActionDescriptor.ActionName}"
            });
        }
    }
}
