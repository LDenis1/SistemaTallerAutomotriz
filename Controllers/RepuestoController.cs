using Dastone.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaContext.Models;
using System.Data;
using System.Diagnostics;

namespace PruebaContext.Controllers
{
    public class RepuestosController : Controller
    {
        private readonly PruebaContexto _context;
        private readonly ILogger<RepuestosController> _logger;

        public RepuestosController(PruebaContexto context, ILogger<RepuestosController> logger)
		{
            _context = context;
            _logger = logger;
        }

		[Authorize(Roles = "Administrador")]
		public IActionResult Index(int id)
        {
            var repuestos = _context.Repuestos.ToList();
            ViewBag.Repuestos = repuestos;
            ViewBag.ID=id;

            return View();
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehiculo vehiculo)
        {
            try
            {
                // Añadir el vehículo al contexto y guardar los cambios
                _context.Vehiculos.Add(vehiculo);
                await _context.SaveChangesAsync();

                // Redirigir a la acción Index después de guardar
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar cualquier error durante el proceso de guardado
                ModelState.AddModelError("", "Error al guardar el vehículo: " + ex.Message);
            }

            // Si hay errores de validación, mostrar la vista nuevamente con los errores
            return View(vehiculo);
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