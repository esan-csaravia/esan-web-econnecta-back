using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface INotificacionesService
    {
        Task<int> CrearNotificacionAsync(Notificaciones notificacion);
        Task<IEnumerable<NotificacionDTO>> GetByUsuarioAsync(int idUsuario);
        Task<IEnumerable<NotificacionDTO>> GetDetalladoByUsuarioAsync(int idUsuario);
    }
}