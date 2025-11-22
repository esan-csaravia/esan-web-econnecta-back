using System;
using System.Collections.Generic;

namespace Web.EcoConecta.CORE.Core.Entities;

public partial class Notificaciones
{
    public int IdNotificacion { get; set; }

    public int IdUsuario { get; set; }

    public int IdPublicacion { get; set; }

    public string? Mensaje { get; set; }

    public bool? Leido { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Publicaciones IdPublicacionNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
