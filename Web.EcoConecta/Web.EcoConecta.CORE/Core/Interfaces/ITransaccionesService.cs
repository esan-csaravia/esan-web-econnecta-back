using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface ITransaccionesService
    {
        Task<int> CrearTransaccionAsync(TransaccionesDTO.CreateTransaccionDTO dto);
        Task<IEnumerable<TransaccionesDTO.TransaccionListDTO>> GetHistorialAsync(int idUsuario);
    }
}