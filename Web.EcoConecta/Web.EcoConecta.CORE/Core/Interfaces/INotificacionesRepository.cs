using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface INotificacionesRepository
    {
        Task<int> Crear(Notificaciones notificacion);
        Task<IEnumerable<Notificaciones>> GetByUsuario(int idUsuario);
        Task<IEnumerable<NotificacionDTO>> GetDetalladoByUsuario(int idUsuario);
    }
}