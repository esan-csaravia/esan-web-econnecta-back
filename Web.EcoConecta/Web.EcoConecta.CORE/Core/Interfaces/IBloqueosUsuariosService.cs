using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface IBloqueosUsuariosService
    {
        Task<int> CrearAsync(BloqueosUsuariosDTO.CreateBloqueoDTO dto);
        Task<int> CrearBloqueo(BloqueosUsuariosDTO.CreateBloqueoDTO dto);
        Task<IEnumerable<BloqueosUsuariosDTO.BloqueoListDTO>> GetHistorialAsync(int idUsuario);
    }
}