using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface ITransaccionesService
    {
        Task<int> CrearTransaccionAsync(TransaccionesDTO.CreateTransaccionDTO dto);
        Task<Transacciones?> GetByIdAsync(int id);
        Task<TransaccionDetalleDTO?> GetDetalleCompraAsync(int id);
        Task<IEnumerable<TransaccionesDTO.HistorialDTO>> GetHistorialAsync(int idUsuario);
    }
}