using System;
using System.Collections.Generic;

namespace Dastone.Entities;

public partial class UserxRol
{
    public int IdUsersxRol { get; set; }

    public int? IdUser { get; set; }

    public int? IdRol { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
