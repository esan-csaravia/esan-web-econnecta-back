using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface IPublicacionesService
    {
        Task<IEnumerable<PublicacionesDTO.PublicacionListDTO>> BuscarAsync(string? titulo, int? categoria, string? distrito);
        Task<int> CrearPublicacionAsync(PublicacionesDTO.CreatePublicacionDTO dto);
        Task<IEnumerable<PublicacionesDTO.PublicacionListDTO>> GetPendientesAsync();
        Task<int> UpdateEstadoAsync(PublicacionesDTO.UpdateEstadoDTO dto);
    }
}