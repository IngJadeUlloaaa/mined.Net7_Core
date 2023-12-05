using Microsoft.AspNetCore.Mvc;
using ProyectoFinalEnt.Controllers;
using ProyectoFinalEnt.Datos;
using ProyectoFinalEnt.Models;
using ProyectoFinalEnt.Servicios.Contratos;

namespace ProyectoFinalEnt.Controllers
{
    public class SpDirectorController : Controller
    {
        SpDirector _SpDirector = new SpDirector();
        
        public IActionResult Listar()
        {
            var lista = _SpDirector.Listar();
            return View(lista);
        }

        public IActionResult Eliminar(int buscarId)
        {
            var buscar = _SpDirector.Buscar(buscarId);
            return View(buscar);
        }

        public IActionResult Editar(int buscarId)
        {
            var buscar = _SpDirector.Buscar(buscarId);
            return View(buscar);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Director edit)
        {

            if (!ModelState.IsValid)
                return View();

            var respuesta = _SpDirector.Editar(edit);

            if (respuesta)
                 return RedirectToAction("Listar", "SpDirector");

            else
                return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(Director eliminar)
        {

            var respuesta = _SpDirector.Eliminar(eliminar.IdD);

            if (respuesta)
                return RedirectToAction("Listar", "SpDirector");

            else
                return RedirectToAction("Index", "Home");

        }

    }
}

