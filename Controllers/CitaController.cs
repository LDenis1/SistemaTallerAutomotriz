using Dastone.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaContext.Models;
using System.Data;
using System.Diagnostics;

namespace PruebaContext.Controllers
{
    public class CitasController : Controller
    {
        private readonly PruebaContexto _context;
        private readonly ILogger<CitasController> _logger;

        public CitasController(PruebaContexto context, ILogger<CitasController> logger)
		{
            _context = context;
            _logger = logger;
        }

		[Authorize(Roles = "Administrador")]
		public IActionResult Index()
        {
            var citum = _context.Cita.ToList();
            return View(citum);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")] // Asegura que solo los administradores puedan acceder a este método
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Citum cita)
        {
            try
            {
                // Asignar la fecha de creación actual si no se proporciona
                if (cita.FechaCreacion == null)
                    cita.FechaCreacion = DateTime.Now;

                // Añadir la cita al contexto y guardar los cambios
                _context.Cita.Add(cita);
                await _context.SaveChangesAsync();

                // Redirigir a la acción Index después de guardar
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar cualquier error durante el proceso de guardado
                ModelState.AddModelError("", "Error al guardar la cita: " + ex.Message);
            }

            // Si hay errores de validación, mostrar la vista nuevamente con los errores
            return View(cita);
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