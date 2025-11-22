using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Core.Services
{
    public class ComentariosService : IComentariosService
    {
        private readonly IComentariosRepository _repo;
        private readonly EcoConectaDbContext _context;

        public ComentariosService(IComentariosRepository repo, EcoConectaDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<int> CrearComentarioAsync(ComentariosDTO.CreateComentarioDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Comentario) || dto.Comentario.Length > 200) return 0;

            var comentario = new Comentarios
            {
                IdPublicacion = dto.IdPublicacion,
                IdUsuario = dto.IdUsuario,
                Comentario = dto.Comentario
            };

            return await _repo.Crear(comentario);
        }

        public async Task<IEnumerable<ComentariosDTO.ComentarioListDTO>> GetByPublicacionAsync(int idPublicacion)
        {
            var list = await _repo.GetByPublicacion(idPublicacion);
            return list.Select(c => new ComentariosDTO.ComentarioListDTO
            {
                IdComentario = c.IdComentario,
                IdPublicacion = c.IdPublicacion,
                IdUsuario = c.IdUsuario,
                Comentario = c.Comentario,
                Fecha = c.Fecha,
                NombreAutor = c.IdUsuarioNavigation?.Nombre
            });
        }
    }
}
