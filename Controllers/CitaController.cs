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

        [Authorize(Roles = "Administrador")]
        public IActionResult CambiarEstado(int id)
        {

            // Obtener la orden de trabajo por su ID
            var cita= _context.Cita
                .FirstOrDefault(o => o.CitaId == id);

            // Verificar si la orden de trabajo existe
            if (cita == null)
            {
                // Manejar el caso en que no se encuentre la orden de trabajo (puede redirigir a una página de error, por ejemplo)
                return NotFound();
            }

            // Pasar la orden de trabajo a la vista "CambiarEstado"
            return View(cita);

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


        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult CambiarEstado(int id, string estadoSeleccionado)
        {
            var cita = _context.Cita.FirstOrDefault(o => o.CitaId == id);

            if (cita == null)
            {
                return NotFound();
            }

            cita.Estado = estadoSeleccionado;

            if (ModelState.IsValid)
            {
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirigir a una página de confirmación o listado de órdenes
            }

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