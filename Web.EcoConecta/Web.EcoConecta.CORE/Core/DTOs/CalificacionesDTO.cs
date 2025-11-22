using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EcoConecta.CORE.Core.DTOs
{
    public class CalificacionesDTO
    {
        public class CreateCalificacionDTO
        {
            public int IdTransaccion { get; set; }
            public int IdCalificador { get; set; }
            public int IdVendedor { get; set; }
            public int Puntuacion { get; set; } // 1-5
            public string? Comentario { get; set; }
        }

        public class CalificacionListDTO
        {
            public int IdCalificacion { get; set; }
            public int IdTransaccion { get; set; }
            public int IdCalificador { get; set; }
            public int IdVendedor { get; set; }
            public int? Puntuacion { get; set; }
            public string? Comentario { get; set; }
            public DateTime? Fecha { get; set; }
        }
    }
}
