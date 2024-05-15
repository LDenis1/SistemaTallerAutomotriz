using System;
using System.Collections.Generic;

namespace Dastone.Entities;

public partial class OrdenTrabajo
{
    public int OrdenId { get; set; }

    public int? ClienteId { get; set; }

    public string? Placa { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? TipoTrabajo { get; set; }

    public string? DetalleOrden { get; set; }

    public string? Estado { get; set; }

    public double? CostoTotal { get; set; }

    public string? Notas { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public string? Observaciones { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Vehiculo? PlacaNavigation { get; set; }

    public virtual ICollection<RepuestoUsado> RepuestoUsados { get; set; } = new List<RepuestoUsado>();
}
