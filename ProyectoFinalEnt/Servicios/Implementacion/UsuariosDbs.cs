using Microsoft.EntityFrameworkCore;
using ProyectoFinalEnt.Models;
using ProyectoFinalEnt.Servicios.Contratos;

namespace ProyectoFinalEnt.Servicios.Implementacion
{
    public class UsuariosDbs : Interface
    {
        private readonly NaeBsdContext _context;

        public UsuariosDbs(NaeBsdContext context)
        {
            _context = context;
        }

        public async Task<Camionero> GetCamionero(string correo, string clave)
        {
           Camionero camionero = await _context.Camioneros.Where
                (u => u.CorreoC == correo && u.ClaveC == clave).FirstOrDefaultAsync();
            return camionero;
        }

        public async Task<Director> GetDirector(string correo, string clave)
        {
            Director director = await _context.Directors.Where
                 (u => u.CorreoD == correo && u.ClaveD == clave).FirstOrDefaultAsync();
            return director;
        }

        public async Task<Camionero> SaveCamionero(Camionero modelo)
        {
            _context.Camioneros.Add(modelo);
            await _context.SaveChangesAsync();

            return modelo;
        }

        public async Task<Director> SaveDirector(Director modelo)
        {
            _context.Directors.Add(modelo);
            await _context.SaveChangesAsync();

            return modelo;
        }
    }
}
