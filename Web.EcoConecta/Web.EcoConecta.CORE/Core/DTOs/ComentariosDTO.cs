using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EcoConecta.CORE.Core.DTOs
{
    public class ComentariosDTO
    {
        public class CreateComentarioDTO
        {
            public int IdPublicacion { get; set; }
            public int IdUsuario { get; set; }
            public string Comentario { get; set; }
        }

        public class ComentarioListDTO
        {
            public int IdComentario { get; set; }
            public int IdPublicacion { get; set; }
            public int IdUsuario { get; set; }
            public string Comentario { get; set; }
            public DateTime? Fecha { get; set; }
            public string? NombreAutor { get; set; }
        }
    }
}
