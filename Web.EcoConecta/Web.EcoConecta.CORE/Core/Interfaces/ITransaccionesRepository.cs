using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface ITransaccionesRepository
    {
        Task<int> Crear(Transacciones transaccion);
        Task<IEnumerable<Transacciones>> GetByUsuario(int idUsuario);
        Task<Transacciones> GetById(int id);
    }
}
