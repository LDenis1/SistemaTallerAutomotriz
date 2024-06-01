using Dastone.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaContext.Models;
using System.Data;
using System.Diagnostics;

namespace PruebaContext.Controllers
{
    public class OrdenTController : Controller
    {
        private readonly PruebaContexto _context;
        private readonly ILogger<OrdenTController> _logger;

        public OrdenTController(PruebaContexto context, ILogger<OrdenTController> logger)
		{
            _context = context;
            _logger = logger;
        }

		[Authorize(Roles = "Administrador")]
		public IActionResult Index()
        {
            var ordenes = _context.OrdenTrabajos.ToList();
            return View(ordenes);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            var vehiculos = _context.Vehiculos.ToList();
            var clientes = _context.Clientes.ToList();

            // Pasar la lista de clientes a la vista
            ViewBag.Vehiculos = vehiculos;
            ViewBag.Clientes = clientes;

            // Renderizar la vista
            return View();
        }

        [Authorize(Roles = "Administrador")]

        public IActionResult Comprobante(int id)
        {
            // Obtener la orden de trabajo por su ID
            var ordenTrabajo = _context.OrdenTrabajos
                .Include(o => o.Cliente) // Incluye el cliente relacionado si es necesario
                .FirstOrDefault(o => o.OrdenId == id);

            // Verificar si la orden de trabajo existe
            if (ordenTrabajo == null)
            {
                // Manejar el caso en que no se encuentre la orden de trabajo (puede redirigir a una página de error, por ejemplo)
                return NotFound();
            }

            // Pasar la orden de trabajo a la vista "Comprobante"
            return View(ordenTrabajo);

        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrdenTrabajo ordenTrabajo)
        {
            try
            {
                // Asignar la fecha de creación actual si no se proporciona
                if (ordenTrabajo.FechaCreacion == default(DateTime))
                    ordenTrabajo.FechaCreacion = DateTime.Now;

                // Asignar el estado inicial si no se proporciona
                if (string.IsNullOrEmpty(ordenTrabajo.Estado))
                    ordenTrabajo.Estado = "Pendiente";

                _context.OrdenTrabajos.Add(ordenTrabajo);
                await _context.SaveChangesAsync();

                // Redirigir a la acción Index después de guardar
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar cualquier error durante el proceso de guardado
                ModelState.AddModelError("", "Error al guardar la orden de trabajo: " + ex.Message);
            }

            // Si hay errores de validación, mostrar la vista nuevamente con los errores
            return View(ordenTrabajo);
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

        [Authorize(Roles = "Administrador")]
        public IActionResult Repuestos(int id)
        {

            return RedirectToAction("Index", "Repuestos", id);
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