using System;
using System.Collections.Generic;

namespace Dastone.Entities;

public partial class Repuesto
{
    public int RepuestoId { get; set; }

    public string? Nombre { get; set; }

    public string? NumeroParte { get; set; }

    public string? Descripcion { get; set; }

    public double? Precio { get; set; }

    public string? Proveedor { get; set; }

    public string? Notas { get; set; }

    public virtual ICollection<RepuestoUsado> RepuestoUsados { get; set; } = new List<RepuestoUsado>();
}
