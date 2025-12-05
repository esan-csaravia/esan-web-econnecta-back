namespace Web.EcoConecta.CORE.Core.DTOs
{
    public class PublicacionesDTO
    {
        // --------------------------
        // CREAR PUBLICACIÓN
        // --------------------------
        public class CreatePublicacionDTO
        {
            public int IdUsuario { get; set; }
            public string Titulo { get; set; }
            public int IdCategoria { get; set; }
            public string Descripcion { get; set; }
            public decimal? Precio { get; set; }
            public List<string> Imagenes { get; set; } = new List<string>();
            public string Tipo { get; set; } // venta o donacion
        }

        // --------------------------
        // LISTA DE PUBLICACIONES
        // --------------------------
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

            // NUEVOS CAMPOS
            public string NombreUsuario { get; set; }
            public string Distrito { get; set; }
            public string ImagenPrincipal { get; set; }
            public DateTime FechaCreacion { get; set; }
        }


        public class UpdateEstadoDTO
        {
            public int IdPublicacion { get; set; }
            public string EstadoPublicacion { get; set; }
            public string? MotivoRechazo { get; set; }
        }

        public class PublicacionDetalleDTO
        {
            public int IdPublicacion { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public decimal? Precio { get; set; }
            public string Categoria { get; set; }
            public int IdCategoria { get; set; }
            public DateTime FechaCreacion { get; set; }

            public List<string> Imagenes { get; set; }
            public VendedorDTO Vendedor { get; set; }
            public List<ComentarioDTO> Comentarios { get; set; }


            public class VendedorDTO
            {
                public int IdUsuario { get; set; }
                public string Nombre { get; set; }
                public string Apellido { get; set; }
                public string Correo { get; set; }
                public string Distrito { get; set; }
                public DateTime FechaRegistro { get; set; }
            }

            public class ComentarioDTO
            {
                public int IdComentario { get; set; }
                public string Usuario { get; set; }
                public string Mensaje { get; set; }
                public DateTime Fecha { get; set; }
            }
        }

      
        public class UpdatePublicacionDTO
        {
            public int IdPublicacion { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public decimal? Precio { get; set; }
            public int IdCategoria { get; set; }
            public List<string> Imagenes { get; set; }
        }
    }
}
