using System;
using System.Collections.Generic;

namespace Web.EcoConecta.CORE.Core.Entities;

public partial class ImagenesPublicacion
{
    public int IdImagen { get; set; }

    public int IdPublicacion { get; set; }

    public string? RutaImagen { get; set; }

    public virtual Publicaciones IdPublicacionNavigation { get; set; } = null!;
}
