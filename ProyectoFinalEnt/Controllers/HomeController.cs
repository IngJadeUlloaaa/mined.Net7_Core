using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalEnt.Models;
using ProyectoFinalEnt.Servicios.Implementacion;
using System.Diagnostics;
using System.Security.Claims;

namespace ProyectoFinalEnt.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Usuario_M()
        {
            return View();
        }


        public IActionResult Index_C()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;
            string usuario = "";
            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                usuario = claimsPrincipal.Claims.Where(c =>
                c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            }
            ViewData["usuario"] = usuario;
            return View();
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;
            string usuario = "";
            if (    claimsPrincipal.Identity.IsAuthenticated)
            {
                usuario = claimsPrincipal.Claims.Where(c =>
                c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            }
            ViewData["usuario"] = usuario;
            return View();
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            return RedirectToAction("IniciarSesion", "Inicio");
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
