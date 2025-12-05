using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EcoConecta.CORE.Core.DTOs
{
    public class NotificacionDTO
    {
        public int IdNotificacion { get; set; }
        public string Mensaje { get; set; }
        public bool Leido { get; set; }
        public DateTime Fecha { get; set; }

        public int IdPublicacion { get; set; }
        public string PublicacionTitulo { get; set; }
        public string Imagen { get; set; }

        // OPCIONAL: tipo de evento
        public string Tipo { get; set; } // compra, venta, calificacion, comentario, interes
    }
}
