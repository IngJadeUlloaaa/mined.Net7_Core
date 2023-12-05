using System;
using System.Collections.Generic;

namespace ProyectoFinalEnt.Models;

public partial class Destino
{
    public int IdD { get; set; }

    public string? CodigoD { get; set; }

    public string? NombreD { get; set; }

    public string? CodigoPpk { get; set; }

    public int? IdDpk2 { get; set; }

    public virtual Paquete? CodigoPpkNavigation { get; set; }

    public virtual Director? IdDpk2Navigation { get; set; }
}
