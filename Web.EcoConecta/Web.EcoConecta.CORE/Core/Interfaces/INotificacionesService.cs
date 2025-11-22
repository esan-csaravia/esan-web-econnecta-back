using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface INotificacionesService
    {
        Task<int> CrearNotificacionAsync(Notificaciones not);
        Task<IEnumerable<Notificaciones>> GetByUsuarioAsync(int idUsuario);
    }
}