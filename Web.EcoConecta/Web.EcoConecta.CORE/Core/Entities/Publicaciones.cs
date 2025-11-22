using System;
using System.Collections.Generic;

namespace Web.EcoConecta.CORE.Core.Entities;

public partial class Publicaciones
{
    public int IdPublicacion { get; set; }

    public int IdUsuario { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal? Precio { get; set; }

    public int IdCategoria { get; set; }

    public string? EstadoPublicacion { get; set; }

    public string? MotivoRechazo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Comentarios> Comentarios { get; set; } = new List<Comentarios>();

    public virtual Categorias IdCategoriaNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<ImagenesPublicacion> ImagenesPublicacion { get; set; } = new List<ImagenesPublicacion>();

    public virtual ICollection<Notificaciones> Notificaciones { get; set; } = new List<Notificaciones>();

    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}
