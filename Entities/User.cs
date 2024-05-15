using System;
using System.Collections.Generic;

namespace Dastone.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<UserxRol> UserxRols { get; set; } = new List<UserxRol>();
}
