using System;
using System.Collections.Generic;

namespace ProyectoFinalEnt.Models;

public partial class Paquete
{
    public string CodigoP { get; set; } = null!;

    public string? DescripP { get; set; }

    public string? NombreInstP { get; set; }

    public string? DirecInstP { get; set; }

    public virtual ICollection<Camionero> Camioneros { get; } = new List<Camionero>();

    public virtual ICollection<Destino> Destinos { get; } = new List<Destino>();
}
