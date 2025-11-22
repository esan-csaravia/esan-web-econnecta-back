using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EcoConecta.CORE.Core.DTOs
{
    public class TransaccionesDTO
    {
        public class CreateTransaccionDTO
        {
            public int IdPublicacion { get; set; }
            public int IdComprador { get; set; }
            public int IdVendedor { get; set; }
            public string Tipo { get; set; } // "compra" o "donacion"
        }

        public class TransaccionListDTO
        {
            public int IdTransaccion { get; set; }
            public int IdPublicacion { get; set; }
            public int IdComprador { get; set; }
            public int IdVendedor { get; set; }
            public string Tipo { get; set; }
            public DateTime? Fecha { get; set; }
        }
    }
}
