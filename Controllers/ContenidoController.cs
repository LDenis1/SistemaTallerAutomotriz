
using Dastone.Entities;
using Dastone.Entities.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaContext.Models;
using System.Data;
using System.Diagnostics;

namespace PruebaContext.Controllers
{
    public class ContenidoController : Controller
    {
        private readonly PruebaContexto _context;

        private readonly ILogger<ContenidoController> _logger;

        public ContenidoController(PruebaContexto context,ILogger<ContenidoController> logger)
		{
            _logger = logger;
            _context= context;
        }
		public IActionResult Index()
        {

            return View();
        }
        public IActionResult Login()
        {

            return RedirectToAction("Index", "Security");
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