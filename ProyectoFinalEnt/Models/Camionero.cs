using System;
using System.Collections.Generic;

namespace ProyectoFinalEnt.Models;

public partial class Camionero
{
    public int IdC { get; set; }

    public string? CedulaC { get; set; }

    public string? LicenciaC { get; set; }

    public string? NombreC { get; set; }

    public string? ApellidoC { get; set; }

    public string? CorreoC { get; set; }

    public string? ClaveC { get; set; }

    public string? CodigoPpk { get; set; }

    public int? IdDpk { get; set; }

    public virtual Paquete? CodigoPpkNavigation { get; set; }

    public virtual ICollection<Conducir> Conducirs { get; } = new List<Conducir>();

    public virtual Director? IdDpkNavigation { get; set; }
}
