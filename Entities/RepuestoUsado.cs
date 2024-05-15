using System;
using System.Collections.Generic;

namespace Dastone.Entities;

public partial class RepuestoUsado
{
    public int RepuestoUsadoId { get; set; }

    public int? OrdenId { get; set; }

    public int? RepuestoId { get; set; }

    public int? Cantidad { get; set; }

    public string? Descripcion { get; set; }

    public double? CostoTotal { get; set; }

    public virtual OrdenTrabajo? Orden { get; set; }

    public virtual Repuesto? Repuesto { get; set; }
}
