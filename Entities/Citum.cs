using System;
using System.Collections.Generic;

namespace Dastone.Entities;

public partial class Citum
{
    public int CitaId { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? TipoServicio { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Notas { get; set; }
}
