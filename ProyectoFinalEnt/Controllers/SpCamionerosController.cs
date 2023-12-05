using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalEnt.Datos;
using ProyectoFinalEnt.Models;
using ProyectoFinalEnt.Servicios.Contratos;

namespace ProyectoFinalEnt.Controllers
{
    public class SpCamionerosController : Controller
    {
        SpCamioneros SpCamioneros = new SpCamioneros();
        NaeBsdContext _context = new NaeBsdContext();

        public SpCamionerosController(NaeBsdContext context)
        {
            _context = context;
        }

        public IActionResult Listar_C()
        {
            var lista = SpCamioneros.Listar();
            return View(lista);
        }

        public IActionResult Eliminar_C(int buscarId)
        {
            var buscar = SpCamioneros.Buscar(buscarId);
            return View(buscar);
        }

        public IActionResult Editar_C(int buscarId)
        {
            var buscar = SpCamioneros.Buscar(buscarId);

            ViewData["CodigoPpk"] = new SelectList(_context.Paquetes, "CodigoP", "CodigoP");
            ViewData["IdDpk"] = new SelectList(_context.Directors, "IdD", "IdD");

            return View(buscar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar_C(Camionero edit)
        {

            if (!ModelState.IsValid)
                return View();

            var respuesta = SpCamioneros.Editar(edit);

            if (respuesta)
                return RedirectToAction("Listar_C", "SpCamioneros");

            else
                return RedirectToAction("Index", "Home");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar_C(Director eliminar)
        {

            var respuesta = SpCamioneros.Eliminar(eliminar.IdD);

            if (respuesta)
                return RedirectToAction("Listar_C", "SpCamioneros");

            else
                return RedirectToAction("Index", "Home");

        }

    }
}
