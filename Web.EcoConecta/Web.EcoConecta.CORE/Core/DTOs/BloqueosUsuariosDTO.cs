using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EcoConecta.CORE.Core.DTOs
{
    public class BloqueosUsuariosDTO
    {
        public class CreateBloqueoDTO
        {
            public int IdUsuario { get; set; }
            public int IdAdmin { get; set; }
            public string Motivo { get; set; }
        }

        public class BloqueoListDTO
        {
            public int IdBloqueo { get; set; }
            public int IdUsuario { get; set; }
            public int IdAdmin { get; set; }
            public string Motivo { get; set; }
            public DateTime? Fecha { get; set; }

            public string NombreUsuario { get; set; }
            public string NombreAdmin { get; set; }
        }
    }
}

