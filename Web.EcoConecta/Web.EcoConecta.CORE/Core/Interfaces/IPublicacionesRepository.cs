using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface IPublicacionesRepository
    {
        Task<int> Actualizar(Publicaciones pub);
        Task<IEnumerable<Publicaciones>> Buscar(string? titulo, int? categoria, string? distrito);
        Task<IEnumerable<Publicaciones>> BuscarAprobadas(string? titulo, int? categoria, string? distrito);
        Task<int> Crear(Publicaciones pub);
        Task<int> Eliminar(int id);
        Task EliminarPublicacionCompleta(int idPublicacion);
        Task<Publicaciones> GetById(int id);
        Task<IEnumerable<Publicaciones>> GetByUsuario(int idUsuario);
        Task<Publicaciones> GetDetalle(int id);
        Task<IEnumerable<Publicaciones>> GetPendientes();
    }
}