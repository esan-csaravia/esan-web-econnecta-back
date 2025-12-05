using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface ICalificacionesService
    {
        Task<int> CrearCalificacionAsync(CalificacionesDTO.CreateCalificacionDTO dto);
        Task<object?> GetCalificacionesVendedorAsync(int idVendedor);
        Task<IEnumerable<CalificacionesDTO.CalificacionListDTO>> GetListaCalificacionesAsync(int idVendedor);
    }
}