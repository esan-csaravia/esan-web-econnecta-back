using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EcoConecta.CORE.Core.DTOs
{
    public class PublicacionesDTO
    {
        public class CreatePublicacionDTO
        {
            public int IdUsuario { get; set; }
            public string Titulo { get; set; }
            public int IdCategoria { get; set; }
            public string Descripcion { get; set; }
            public decimal? Precio { get; set; }
            // Lista de rutas o nombres de archivos (se puede adaptar a archivos en el API)
            public List<string> Imagenes { get; set; } = new List<string>();
            public string Tipo { get; set; } // "venta" o "donacion"
        }

        public class PublicacionListDTO
        {
            public int IdPublicacion { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public decimal? Precio { get; set; }
            public string EstadoPublicacion { get; set; }
            public int IdUsuario { get; set; }
            public int IdCategoria { get; set; }
            public List<string> Imagenes { get; set; } = new List<string>();
        }

        public class UpdateEstadoDTO
        {
            public int IdPublicacion { get; set; }
            public string EstadoPublicacion { get; set; }
            public string? MotivoRechazo { get; set; }
        }
    }
}
