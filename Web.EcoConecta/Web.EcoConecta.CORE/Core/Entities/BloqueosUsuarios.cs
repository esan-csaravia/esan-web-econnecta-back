using System;
using System.Collections.Generic;

namespace Web.EcoConecta.CORE.Core.Entities;

public partial class BloqueosUsuarios
{
    public int IdBloqueo { get; set; }

    public int IdUsuario { get; set; }

    public int IdAdmin { get; set; }

    public string Motivo { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public virtual Usuarios IdAdminNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
