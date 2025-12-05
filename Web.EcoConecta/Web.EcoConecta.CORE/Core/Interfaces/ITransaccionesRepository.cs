using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface ITransaccionesRepository
    {
        Task<int> Crear(Transacciones transaccion);
        Task<Transacciones> GetById(int id);
        Task<Transacciones?> GetByIdDetalle(int id);
        Task<IEnumerable<Transacciones>> GetByUsuario(int idUsuario);
    }
}