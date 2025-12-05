using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface IPublicacionesService
    {
        Task<IEnumerable<PublicacionesDTO.PublicacionListDTO>> BuscarAprobadasAsync(string? titulo, int? categoria, string? distrito);
        Task<IEnumerable<PublicacionesDTO.PublicacionListDTO>> BuscarAsync(string? titulo, int? categoria, string? distrito);
        Task<int> CrearPublicacionAsync(PublicacionesDTO.CreatePublicacionDTO dto);
        Task<int> EditarPublicacionAsync(PublicacionesDTO.UpdatePublicacionDTO dto);
        Task<bool> EliminarPublicacionAsync(int idPublicacion);
        Task<IEnumerable<PublicacionesDTO.PublicacionListDTO>> GetByUsuarioAsync(int idUsuario);
        Task<PublicacionesDTO.PublicacionDetalleDTO?> GetDetalleAsync(int id);
        Task<IEnumerable<PublicacionesDTO.PublicacionListDTO>> GetPendientesAsync();
        Task<int> UpdateEstadoAsync(PublicacionesDTO.UpdateEstadoDTO dto);
    }
}