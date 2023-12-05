using Microsoft.EntityFrameworkCore;
using ProyectoFinalEnt.Models;

namespace ProyectoFinalEnt.Servicios.Contratos
{
    public interface Interface
    {
        //Director que pertenece a Models

        //Primer metodo solo devolvera un usuario atraves de un correo y una clave que le pasamos  
        Task<Director> GetDirector(string correo, string clave);
        Task<Camionero> GetCamionero(string correo, string clave);

        //Guardamos solo
        Task<Director> SaveDirector(Director modelo);
        Task<Camionero> SaveCamionero(Camionero modelo);
    }
}
