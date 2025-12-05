using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EcoConecta.CORE.Core.DTOs
{
    public class CategoriasDTO
    {
        public class CategoriaCreateDTO
        {
            public string Nombre { get; set; }
        }

        public class CategoriaListDTO
        {
            public int IdCategoria { get; set; }
            public string Nombre { get; set; }
        }
    }
}

