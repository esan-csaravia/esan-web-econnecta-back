using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface IBloqueosUsuariosRepository
    {
        Task<int> CrearAsync(BloqueosUsuarios bloqueo);
        Task<IEnumerable<BloqueosUsuarios>> GetByUsuarioAsync(int idUsuario);
    }
}