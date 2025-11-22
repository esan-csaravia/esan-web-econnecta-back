using System;
using System.Collections.Generic;

namespace Web.EcoConecta.CORE.Core.Entities;

public partial class Calificaciones
{
    public int IdCalificacion { get; set; }

    public int IdTransaccion { get; set; }

    public int IdCalificador { get; set; }

    public int IdVendedor { get; set; }

    public int? Puntuacion { get; set; }

    public string? Comentario { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Usuarios IdCalificadorNavigation { get; set; } = null!;

    public virtual Transacciones IdTransaccionNavigation { get; set; } = null!;

    public virtual Usuarios IdVendedorNavigation { get; set; } = null!;
}
