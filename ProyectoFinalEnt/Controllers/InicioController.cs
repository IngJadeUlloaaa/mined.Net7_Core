using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalEnt.Controllers;
using ProyectoFinalEnt.Models;
using ProyectoFinalEnt.Servicios.Contratos;
using System.Security.Claims;
using ProyectoFinalEnt.Datos;
using ProyectoFinalEnt.Seguridad;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinalEnt.Controllers
{
    public class InicioController : Controller
    {
        private readonly Interface _interface;
        SpDirector _SpDirector = new SpDirector();
        NaeBsdContext _context = new NaeBsdContext();

        public InicioController(Interface interfaces, NaeBsdContext context)
        {
            _interface = interfaces;
            _context = context;
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }
        public IActionResult Usuarios()
        {
            return View();
        }
        public IActionResult Registrarse_C()
        {
            ViewData["CodigoPpk"] = new SelectList(_context.Paquetes, "CodigoP", "CodigoP");
            ViewData["IdDpk"] = new SelectList(_context.Directors, "IdD", "IdD");
            return View();
        }

        public IActionResult Registrarse_D()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrarse_C(Camionero modelo)
        {

            modelo.ClaveC = Encriptacion.EncriptarClave(modelo.ClaveC);
            Camionero creado_C = await _interface.SaveCamionero(modelo);

            if (creado_C.IdC < 0)
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }

            else
            {
                ViewData["Mensaje"] = "No se pudo crear el usuario";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse_D(Director modelo)
        {

            if (!ModelState.IsValid)
                return View();

            modelo.ClaveD = Encriptacion.EncriptarClave(modelo.ClaveD);
            Director creado_D = await _interface.SaveDirector(modelo);
            
            if (creado_D.IdD < 0)
                return RedirectToAction("IniciarSesion", "Inicio");

            else
            {
                ViewData["Mensaje"] = "No se pudo crear el usuario";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {

            Camionero encontrado_C = await _interface.GetCamionero
                (correo, Encriptacion.EncriptarClave(clave));

            Director encontrado_D = await _interface.GetDirector
                (correo, Encriptacion.EncriptarClave(clave));
            
            if (encontrado_D == null)
            {
                List<Claim> claim_C = new List<Claim>()
                { new Claim(ClaimTypes.Name, encontrado_C.NombreC)};

                ClaimsIdentity claimsIdentity2 = new ClaimsIdentity(claim_C, CookieAuthenticationDefaults.
                    AuthenticationScheme);
                AuthenticationProperties properties2 = new AuthenticationProperties() { AllowRefresh = true };

                await HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                      new ClaimsPrincipal(claimsIdentity2), properties2);

                return RedirectToAction("Index_C", "Home");
            }
            
            if (encontrado_C == null)
            {
                List<Claim> claim_D = new List<Claim>()
                { new Claim(ClaimTypes.Name, encontrado_D.NombreD)};

                ClaimsIdentity claimsIdentity1 = new ClaimsIdentity(claim_D, CookieAuthenticationDefaults.
                    AuthenticationScheme);

                AuthenticationProperties properties1 = new AuthenticationProperties() { AllowRefresh = true };
                await HttpContext.SignInAsync(

                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity1), properties1);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }




    }
}
