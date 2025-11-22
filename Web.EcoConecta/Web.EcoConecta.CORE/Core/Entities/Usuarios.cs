using System;
using System.Collections.Generic;

namespace Web.EcoConecta.CORE.Core.Entities;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string Correo { get; set; } = null!;

    public string? Distrito { get; set; }

    public string Contrasena { get; set; } = null!;

    public string? Rol { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<BloqueosUsuarios> BloqueosUsuariosIdAdminNavigation { get; set; } = new List<BloqueosUsuarios>();

    public virtual ICollection<BloqueosUsuarios> BloqueosUsuariosIdUsuarioNavigation { get; set; } = new List<BloqueosUsuarios>();

    public virtual ICollection<Calificaciones> CalificacionesIdCalificadorNavigation { get; set; } = new List<Calificaciones>();

    public virtual ICollection<Calificaciones> CalificacionesIdVendedorNavigation { get; set; } = new List<Calificaciones>();

    public virtual ICollection<CampanasReciclaje> CampanasReciclaje { get; set; } = new List<CampanasReciclaje>();

    public virtual ICollection<Comentarios> Comentarios { get; set; } = new List<Comentarios>();

    public virtual ICollection<Notificaciones> Notificaciones { get; set; } = new List<Notificaciones>();

    public virtual ICollection<Publicaciones> Publicaciones { get; set; } = new List<Publicaciones>();

    public virtual ICollection<Transacciones> TransaccionesIdCompradorNavigation { get; set; } = new List<Transacciones>();

    public virtual ICollection<Transacciones> TransaccionesIdVendedorNavigation { get; set; } = new List<Transacciones>();
}
