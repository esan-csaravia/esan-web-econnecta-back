using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Core.Services
{
    public class NotificacionesService : INotificacionesService
    {
        private readonly INotificacionesRepository _repo;

        public NotificacionesService(INotificacionesRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> CrearNotificacionAsync(Notificaciones notificacion)
        {
            return await _repo.Crear(notificacion);
        }

        // ESTE ES EL ÚNICO QUE SE USARÁ EN EL CONTROLADOR
        public async Task<IEnumerable<NotificacionDTO>> GetByUsuarioAsync(int idUsuario)
        {
            // OBTIENE LOS DATOS DETALLADOS (JOIN con Publicaciones e Imagenes)
            return await _repo.GetDetalladoByUsuario(idUsuario);
        }

        // OPCIONAL: si quieres un endpoint exclusivo para "detallado"
        public async Task<IEnumerable<NotificacionDTO>> GetDetalladoByUsuarioAsync(int idUsuario)
        {
            return await _repo.GetDetalladoByUsuario(idUsuario);
        }
    }
}
