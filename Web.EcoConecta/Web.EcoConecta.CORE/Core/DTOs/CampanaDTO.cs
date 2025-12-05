using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EcoConecta.CORE.Core.DTOs
{
    public class CampanaDTO
    {
        public class CreateCampanaDTO
        {
            public int IdAdmin { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string? Imagen { get; set; }
            public DateOnly FechaCampana { get; set; }
        }

        public class CampanaListDTO
        {
            public int IdCampana { get; set; }
            public int IdAdmin { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string? Imagen { get; set; }
            public DateTime? FechaPublicacion { get; set; }
        }

    }
}
