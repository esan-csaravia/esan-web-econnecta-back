using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface ICampanasRepository
    {
        Task<int> Crear(CampanasReciclaje campana);
        Task<int> Actualizar(CampanasReciclaje campana);
        Task<int> Eliminar(int id);
        Task<IEnumerable<CampanasReciclaje>> GetAllActive();
    }
}
