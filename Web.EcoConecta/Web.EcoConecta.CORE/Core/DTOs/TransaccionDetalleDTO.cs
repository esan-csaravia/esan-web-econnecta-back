using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EcoConecta.CORE.Core.DTOs
{
    public class TransaccionDetalleDTO
    {
        public int IdTransaccion { get; set; }
        public DateTime? Fecha { get; set; }

        public PublicacionDetalleDTO Publicacion { get; set; }
        public UsuarioSimpleDTO Vendedor { get; set; }
    }

    public class PublicacionDetalleDTO
    {
        public string Titulo { get; set; }
        public decimal Precio { get; set; }
        public List<string> Imagenes { get; set; }
    }

    public class UsuarioSimpleDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
