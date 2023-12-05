using System;
using System.Collections.Generic;

namespace ProyectoFinalEnt.Models;

public partial class Camion
{
    public string MatriculaCn { get; set; } = null!;

    public string? ModeloCn { get; set; }

    public string? TipoCn { get; set; }

    public virtual ICollection<Conducir> Conducirs { get; } = new List<Conducir>();
}
