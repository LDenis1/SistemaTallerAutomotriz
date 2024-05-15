using Microsoft.AspNetCore.Mvc;
using PruebaContext.Models;
using Dastone.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace PruebaContext.Controllers
{
    public class ClienteController : Controller
    {
        private readonly PruebaContexto _context;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(PruebaContexto context, ILogger<ClienteController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Index()
        {
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
           
                try
                {
                    // Asignar la fecha de registro actual si no se proporciona
                    if (cliente.FechaRegistro == null)
                        cliente.FechaRegistro = DateTime.Now;

                    _context.Clientes.Add(cliente);
                    await _context.SaveChangesAsync();

                    // Redirigir a la acción Index después de guardar
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Manejar cualquier error durante el proceso de guardado
                    ModelState.AddModelError("", "Error al guardar el cliente: " + ex.Message);
                }
            
            // Si hay errores de validación, mostrar la vista nuevamente con los errores
            return View(cliente);
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