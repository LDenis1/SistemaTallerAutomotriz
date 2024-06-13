using Dastone.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaContext.Models;

using System.Data;
using System.Diagnostics;

namespace PruebaContext.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly PruebaContexto _context;
        private readonly ILogger<VehiculoController> _logger;

        public VehiculoController(PruebaContexto context, ILogger<VehiculoController> logger)
		{
            _context = context;
            _logger = logger;
        }

		[Authorize(Roles = "Administrador")]
		public IActionResult Index()
        {
            var vehiculos = _context.Vehiculos.ToList();
            return View(vehiculos);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        { // Recuperar la lista de clientes disponibles de la base de datos
            var clientes = _context.Clientes.ToList();

            // Pasar la lista de clientes a la vista
            ViewBag.Clientes = clientes;

            // Renderizar la vista
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
                return RedirectToAction("Create","OrdenT");
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