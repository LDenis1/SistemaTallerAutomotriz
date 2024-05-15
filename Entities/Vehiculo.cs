using System;
using System.Collections.Generic;

namespace Dastone.Entities;

public partial class Vehiculo
{
    public int VehiculoId { get; set; }

    public string Placa { get; set; } = null!;

    public int? ClienteId { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Anio { get; set; }

    public string? Color { get; set; }

    public string? Kilometraje { get; set; }

    public string? Notas { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<OrdenTrabajo> OrdenTrabajos { get; set; } = new List<OrdenTrabajo>();
}
