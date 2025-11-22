using System;
using System.Collections.Generic;

namespace Web.EcoConecta.CORE.Core.Entities;

public partial class Comentarios
{
    public int IdComentario { get; set; }

    public int IdPublicacion { get; set; }

    public int IdUsuario { get; set; }

    public string Comentario { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public virtual Publicaciones IdPublicacionNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
