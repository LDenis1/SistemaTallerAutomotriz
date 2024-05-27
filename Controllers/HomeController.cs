using Dastone.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaContext.Models;
using System.Data;
using System.Diagnostics;

namespace PruebaContext.Controllers
{
    public class HomeController : Controller
    {
        private readonly PruebaContexto _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(PruebaContexto context,ILogger<HomeController> logger)
		{
            _logger = logger;
            _context= context;
        }

		[Authorize(Roles = "Administrador")]
		public IActionResult Index()
        {
            // Contar el número de tablas en la base de datos
            var numeroDeTablas = _context.Clientes.Count();
            var numeroDeCitas = _context.Cita.Count();
            var numeroDeOrdenes = _context.OrdenTrabajos.Count();


            // Pasar el número de tablas a la vista
            ViewBag.NumeroDeTablas = numeroDeTablas;
            ViewBag.NumeroDeCitas = numeroDeCitas;
            ViewBag.NumeroDeOrdenes = numeroDeOrdenes;

            return View();
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