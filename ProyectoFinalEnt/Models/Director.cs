using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalEnt.Models;

public partial class Director
{
    public int IdD { get; set; }

    [Required(ErrorMessage = "El campo de la cedula es obligatorio")]
    public string? CedulaD { get; set; }

    public string? NombreD { get; set; }

    public string? ApellidoD { get; set; }

    public string? NombreInstD { get; set; }

    [Required(ErrorMessage = "El campo de correo electronico es obligatorio")]
    public string? CorreoD { get; set; }

    [Required(ErrorMessage = "El campo de la contraseña es obligatorio")]
    public string? ClaveD { get; set; }

    public virtual ICollection<Camionero> Camioneros { get; } = new List<Camionero>();

    public virtual ICollection<Destino> Destinos { get; } = new List<Destino>();
}
