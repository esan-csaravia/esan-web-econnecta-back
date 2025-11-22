using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Infraestructure.Repositories
{
    public class NotificacionesRepository : INotificacionesRepository
    {
        private readonly EcoConectaDbContext _context;
        public NotificacionesRepository(EcoConectaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Crear(Notificaciones notificacion)
        {
            await _context.Notificaciones.AddAsync(notificacion);
            await _context.SaveChangesAsync();
            return notificacion.IdNotificacion;
        }

        public async Task<IEnumerable<Notificaciones>> GetByUsuario(int idUsuario)
        {
            return await _context.Notificaciones.Where(n => n.IdUsuario == idUsuario).OrderByDescending(n => n.Fecha).ToListAsync();
        }
    }
}
