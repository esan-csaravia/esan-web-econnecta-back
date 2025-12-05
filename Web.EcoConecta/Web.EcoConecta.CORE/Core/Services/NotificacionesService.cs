using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Core.Services
{
    public class NotificacionesService : INotificacionesService
    {
        private readonly INotificacionesRepository _repo;
        private readonly EcoConectaDbContext _context;

        public NotificacionesService(INotificacionesRepository repo, EcoConectaDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<int> CrearNotificacionAsync(Notificaciones not)
        {
            // Persistir y (opcional) envío de correo
            return await _repo.Crear(not);
        }

        public async Task<IEnumerable<Notificaciones>> GetByUsuarioAsync(int idUsuario)
        {
            return await _repo.GetByUsuario(idUsuario);
        }
    }
}
