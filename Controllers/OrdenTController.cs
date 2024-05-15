using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaContext.Models;
using System.Data;
using System.Diagnostics;

namespace PruebaContext.Controllers
{
    public class OrdenTController : Controller
    {
        private readonly ILogger<OrdenTController> _logger;

        public OrdenTController(ILogger<OrdenTController> logger)
		{
            _logger = logger;
        }

		[Authorize(Roles = "Administrador")]
		public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Select()
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult CLVH()
        {

            return RedirectToAction("Create", "Cliente");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}