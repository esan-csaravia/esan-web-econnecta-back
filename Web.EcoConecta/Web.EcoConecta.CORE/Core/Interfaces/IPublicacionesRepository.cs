using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface IPublicacionesRepository
    {
        Task<int> Crear(Publicaciones pub);
        Task<int> Actualizar(Publicaciones pub);
        Task<int> Eliminar(int id);
        Task<Publicaciones> GetById(int id);
        Task<IEnumerable<Publicaciones>> GetPendientes();
        Task<IEnumerable<Publicaciones>> Buscar(string? titulo, int? categoria, string? distrito);
    }
}
