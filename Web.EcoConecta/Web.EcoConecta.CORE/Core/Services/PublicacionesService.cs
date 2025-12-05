using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Core.Services
{
    public class PublicacionesService : IPublicacionesService
    {
        private readonly IPublicacionesRepository _repo;
        private readonly EcoConectaDbContext _context;

        public PublicacionesService(IPublicacionesRepository repo, EcoConectaDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<int> CrearPublicacionAsync(PublicacionesDTO.CreatePublicacionDTO dto)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(dto.Titulo) || string.IsNullOrWhiteSpace(dto.Descripcion)) return 0;
            if (dto.Imagenes == null || dto.Imagenes.Count == 0) return 0;

            var pub = new Publicaciones
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                IdCategoria = dto.IdCategoria,
                IdUsuario = dto.IdUsuario,
                Precio = dto.Precio,
                EstadoPublicacion = "pendiente",
                // FechaCreacion defaults to DB
            };

            var id = await _repo.Crear(pub);

            // Guardar registros de imagenes (solo rutas/nombres)
            foreach (var img in dto.Imagenes)
            {
                var imagen = new ImagenesPublicacion
                {
                    IdPublicacion = id,
                    RutaImagen = img
                };
                _context.ImagenesPublicacion.Add(imagen);
            }
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<IEnumerable<PublicacionesDTO.PublicacionListDTO>> BuscarAsync(string? titulo, int? categoria, string? distrito)
        {
            var pubs = await _repo.Buscar(titulo, categoria, distrito);
            return pubs.Select(p => new PublicacionesDTO.PublicacionListDTO
            {
                IdPublicacion = p.IdPublicacion,
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                Precio = p.Precio.HasValue ? p.Precio : null,
                EstadoPublicacion = p.EstadoPublicacion,
                IdUsuario = p.IdUsuario,
                IdCategoria = p.IdCategoria,
                Imagenes = p.ImagenesPublicacion.Select(i => i.RutaImagen).ToList()
            });
        }

        public async Task<IEnumerable<PublicacionesDTO.PublicacionListDTO>> GetPendientesAsync()
        {
            var pubs = await _repo.GetPendientes();
            return pubs.Select(p => new PublicacionesDTO.PublicacionListDTO
            {
                IdPublicacion = p.IdPublicacion,
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                Precio = p.Precio.HasValue ? p.Precio : null,
                EstadoPublicacion = p.EstadoPublicacion,
                IdUsuario = p.IdUsuario,
                IdCategoria = p.IdCategoria,
                Imagenes = p.ImagenesPublicacion.Select(i => i.RutaImagen).ToList()
            });
        }

        public async Task<int> UpdateEstadoAsync(PublicacionesDTO.UpdateEstadoDTO dto)
        {
            var pub = await _repo.GetById(dto.IdPublicacion);
            if (pub == null) return 0;
            pub.EstadoPublicacion = dto.EstadoPublicacion;
            pub.MotivoRechazo = dto.MotivoRechazo;
            return await _repo.Actualizar(pub);
        }

        public async Task<IEnumerable<PublicacionesDTO.PublicacionListDTO>> BuscarAprobadasAsync(string? titulo, int? categoria, string? distrito)
        {
            var pubs = await _repo.BuscarAprobadas(titulo, categoria, distrito);

            return pubs.Select(p => new PublicacionesDTO.PublicacionListDTO
            {
                IdPublicacion = p.IdPublicacion,
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                EstadoPublicacion = p.EstadoPublicacion,
                IdUsuario = p.IdUsuario,
                IdCategoria = p.IdCategoria,
                Imagenes = p.ImagenesPublicacion.Select(i => i.RutaImagen).ToList(),

                // NUEVO
                NombreUsuario = p.IdUsuarioNavigation.Nombre + " " + p.IdUsuarioNavigation.Apellido,
                Distrito = p.IdUsuarioNavigation.Distrito
            });
        }

        public async Task<PublicacionesDTO.PublicacionDetalleDTO?> GetDetalleAsync(int id)
        {
            var p = await _repo.GetDetalle(id);
            if (p == null) return null;

            return new PublicacionesDTO.PublicacionDetalleDTO
            {
                IdPublicacion = p.IdPublicacion,
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Categoria = p.IdCategoriaNavigation?.Nombre,
                FechaCreacion = p.FechaCreacion ?? DateTime.MinValue,
                Imagenes = p.ImagenesPublicacion.Select(i => i.RutaImagen).ToList(),

                Vendedor = new PublicacionesDTO.PublicacionDetalleDTO.VendedorDTO
                {
                    IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                    Nombre = p.IdUsuarioNavigation.Nombre,
                    Apellido = p.IdUsuarioNavigation.Apellido,
                    Correo = p.IdUsuarioNavigation.Correo,
                    Distrito = p.IdUsuarioNavigation.Distrito,
                    FechaRegistro = p.IdUsuarioNavigation.FechaRegistro ?? DateTime.MinValue
                },

                Comentarios = p.Comentarios.Select(c => new PublicacionesDTO.PublicacionDetalleDTO.ComentarioDTO
                {
                    IdComentario = c.IdComentario,
                    Usuario = c.IdUsuarioNavigation.Nombre + " " + c.IdUsuarioNavigation.Apellido,
                    Mensaje = c.Comentario,
                    Fecha = c.Fecha ?? DateTime.MinValue
                }).ToList()
            };
        }


    }
}
