using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.DTOs;
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
            return await _context.Notificaciones
                .Where(n => n.IdUsuario == idUsuario)
                .OrderByDescending(n => n.Fecha)
                .ToListAsync();
        }

        public async Task<IEnumerable<NotificacionDTO>> GetDetalladoByUsuario(int idUsuario)
        {
            return await _context.Notificaciones
                .Where(n => n.IdUsuario == idUsuario)
                .OrderByDescending(n => n.Fecha)
                .Select(n => new NotificacionDTO
                {
                    IdNotificacion = n.IdNotificacion,
                    Mensaje = n.Mensaje,
                    Fecha = n.Fecha ?? DateTime.MinValue,
                    Leido = n.Leido ?? false,
                    IdPublicacion = n.IdPublicacion,

                    // JOINS
                    PublicacionTitulo = n.IdPublicacionNavigation.Titulo,
                    Imagen = n.IdPublicacionNavigation.ImagenesPublicacion
                                .Select(i => i.RutaImagen)
                                .FirstOrDefault() ?? "/uploads/default.jpg",

                    // Detectar tipo según el mensaje
                    Tipo =
                        n.Mensaje.Contains("mostró interés") ? "interes" :
                        n.Mensaje.Contains("Has comprado el producto") ? "compra" :
                        n.Mensaje.Contains("ha comprado tu producto") ? "venta" :
                        n.Mensaje.Contains("calific") ? "calificacion" :
                        n.Mensaje.Contains("coment") ? "comentario" :
                        "general"
                })
                .ToListAsync();
        }
    }
}
