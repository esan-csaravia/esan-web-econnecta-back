using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface IComentariosService
    {
        Task<int> CrearComentarioAsync(ComentariosDTO.CreateComentarioDTO dto);
        Task<IEnumerable<ComentariosDTO.ComentarioListDTO>> GetByPublicacionAsync(int idPublicacion);
    }
}