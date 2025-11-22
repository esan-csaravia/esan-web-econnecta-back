using System;
using System.Collections.Generic;

namespace Web.EcoConecta.CORE.Core.Entities;

public partial class CampanasReciclaje
{
    public int IdCampana { get; set; }

    public int IdAdmin { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? Imagen { get; set; }

    public DateOnly FechaCampana { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public virtual Usuarios IdAdminNavigation { get; set; } = null!;
}
