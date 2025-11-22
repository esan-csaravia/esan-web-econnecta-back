using System;
using System.Collections.Generic;

namespace Web.EcoConecta.CORE.Core.Entities;

public partial class Transacciones
{
    public int IdTransaccion { get; set; }

    public int IdPublicacion { get; set; }

    public int IdComprador { get; set; }

    public int IdVendedor { get; set; }

    public string Tipo { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public virtual Calificaciones? Calificaciones { get; set; }

    public virtual Usuarios IdCompradorNavigation { get; set; } = null!;

    public virtual Publicaciones IdPublicacionNavigation { get; set; } = null!;

    public virtual Usuarios IdVendedorNavigation { get; set; } = null!;
}
