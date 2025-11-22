using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Web.EcoConecta.CORE.Core.Services
{
    public class TransaccionesService : ITransaccionesService
    {
        private readonly ITransaccionesRepository _repo;
        private readonly EcoConectaDbContext _context;

        public TransaccionesService(ITransaccionesRepository repo, EcoConectaDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<int> CrearTransaccionAsync(TransaccionesDTO.CreateTransaccionDTO dto)
        {
            // Validaciones básicas
            var publicacion = await _context.Publicaciones.FindAsync(dto.IdPublicacion);
            if (publicacion == null) return 0;

            var transaccion = new Transacciones
            {
                IdPublicacion = dto.IdPublicacion,
                IdComprador = dto.IdComprador,
                IdVendedor = dto.IdVendedor,
                Tipo = dto.Tipo,
                // Fecha default DB
            };

            var id = await _repo.Crear(transaccion);

            // Crear notificación al vendedor
            var notificacion = new Notificaciones
            {
                IdPublicacion = dto.IdPublicacion,
                IdUsuario = dto.IdVendedor,
                Mensaje = "Alguien mostró interés en su publicación",
                Leido = false
            };
            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<IEnumerable<TransaccionesDTO.TransaccionListDTO>> GetHistorialAsync(int idUsuario)
        {
            var trans = await _repo.GetByUsuario(idUsuario);
            return trans.Select(t => new TransaccionesDTO.TransaccionListDTO
            {
                IdTransaccion = t.IdTransaccion,
                IdPublicacion = t.IdPublicacion,
                IdComprador = t.IdComprador,
                IdVendedor = t.IdVendedor,
                Tipo = t.Tipo,
                Fecha = t.Fecha
            });
        }
    }
}
