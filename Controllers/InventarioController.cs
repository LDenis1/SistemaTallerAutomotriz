using Dastone.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaContext.Models;
using System.Data;
using System.Diagnostics;

namespace PruebaContext.Controllers
{
    public class InventarioController : Controller
    {
        private readonly PruebaContexto _context;
        private readonly ILogger<InventarioController> _logger;

        public InventarioController(PruebaContexto context, ILogger<InventarioController> logger)
		{
            _context = context;
            _logger = logger;
        }

		[Authorize(Roles = "Administrador")]
		public IActionResult Index()
        {
            var inventario = _context.Repuestos.ToList();
            return View(inventario);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")] // Asegura que solo los administradores puedan acceder a este método
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Repuesto repuesto)
        {
            try
            {
                // Añadir el artículo al contexto y guardar los cambios
                _context.Repuestos.Add(repuesto);
                await _context.SaveChangesAsync();

                // Redirigir a la acción Index después de guardar
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar cualquier error durante el proceso de guardado
                ModelState.AddModelError("", "Error al guardar el artículo: " + ex.Message);
            }

            // Si hay errores de validación, mostrar la vista nuevamente con los errores
            return View(repuesto);
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