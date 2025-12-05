using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface IComentariosRepository
    {
        Task<int> Crear(Comentarios comentario);
        Task<IEnumerable<Comentarios>> GetByPublicacion(int idPublicacion);
    }
}