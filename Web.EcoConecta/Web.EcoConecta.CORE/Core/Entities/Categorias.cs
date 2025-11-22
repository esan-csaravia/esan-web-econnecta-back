using System;
using System.Collections.Generic;

namespace Web.EcoConecta.CORE.Core.Entities;

public partial class Categorias
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Publicaciones> Publicaciones { get; set; } = new List<Publicaciones>();
}
