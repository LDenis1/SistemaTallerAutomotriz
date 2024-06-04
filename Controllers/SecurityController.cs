using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dastone.Entities;
using Dastone.Entities.Login;
using System.Security.Claims;

namespace PruebaContext.Controllers
{
    public class SecurityController : Controller
    {
        private readonly PruebaContexto _context;
        public SecurityController(PruebaContexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            User? usuario = _context.Users.Include(x => x.UserxRols)
                                        .FirstOrDefault(x => x.Usuario == login.Usuario && x.Contraseña == login.Contraseña);

            if (usuario == null)
            {
                // Manejar el caso cuando el usuario no existe
                // Puedes redirigir a una vista de error o mostrar un mensaje de error
                return RedirectToAction("Error", "Home");
            }

            try
            {
                string rolName = usuario.UserxRols.FirstOrDefault()?.IdUserNavigation.Nombre;
                if (usuario != null && !string.IsNullOrEmpty(rolName))
                {
                    var claims = new List<Claim>()
            {
                new Claim("IDUser", usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, rolName)
            };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                        new AuthenticationProperties()
                        {
                            IsPersistent = login.Recordarme
                        });
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Manejar cualquier otra excepción que pueda ocurrir
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Logout()
        {
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return LocalRedirect("/");
        }
    }
}
