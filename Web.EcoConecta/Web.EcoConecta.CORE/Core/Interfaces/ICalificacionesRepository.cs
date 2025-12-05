using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface ICalificacionesRepository
    {
        Task<int> Crear(Calificaciones calificacion);
        Task<bool> ExistePorTransaccion(int idTransaccion);
        Task<IEnumerable<Calificaciones>> GetByVendedor(int idVendedor);
        Task<IEnumerable<Calificaciones>> GetListaByVendedor(int idVendedor);
    }
}