using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using ProyectoFinalEnt.Datos;
using ProyectoFinalEnt.Models;
using ProyectoFinalEnt.Seguridad;
using ProyectoFinalEnt.Servicios.Contratos;

namespace ProyectoFinalEnt.Controllers
{
    public class SpPaqueteController : Controller
    {
        SpPaquete _SpPaquete = new SpPaquete();

        public IActionResult Registrarse_P()
        {
            return View();
        }

        public IActionResult Listar_P()
        {
            var lista = _SpPaquete.Listar();
            return View(lista);
        }

        public IActionResult Editar_P(string buscarId)
        {
            var buscar = _SpPaquete.Buscar(buscarId);
            return View(buscar);
        }
        public IActionResult Eliminar_P(string buscarId)
        {
            var buscar = _SpPaquete.Buscar(buscarId);
            return View(buscar);
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse_P(Paquete creado)
        {

            var respuesta = _SpPaquete.Resgistrar(creado);
            
            if(respuesta)
            return RedirectToAction("Listar_P");

            else
            {
                ViewData["Mensaje"] = "No se pudo crear el usuario";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar_P(Paquete edit)
        {

            var respuesta = _SpPaquete.Editar(edit);

            if (respuesta)
                return RedirectToAction("Listar_P");

            else
                return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Eliminar_P(Paquete eliminar)
        {

            var respuesta = _SpPaquete.Eliminar(eliminar.CodigoP);

            if (respuesta)
                return RedirectToAction("Listar_P");

            else
                return RedirectToAction("Index", "Home");

        }

    }
}