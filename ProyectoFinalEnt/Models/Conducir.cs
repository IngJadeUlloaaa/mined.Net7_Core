using System;
using System.Collections.Generic;

namespace ProyectoFinalEnt.Models;

public partial class Conducir
{
    public int IdCd { get; set; }

    public int? IdCpk { get; set; }

    public string? IdCnpk { get; set; }

    public virtual Camion? IdCnpkNavigation { get; set; }

    public virtual Camionero? IdCpkNavigation { get; set; }
}
