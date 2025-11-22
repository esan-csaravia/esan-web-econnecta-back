using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Core.Services
{
    public class CalificacionesService : ICalificacionesService
    {
        private readonly ICalificacionesRepository _repo;
        private readonly ITransaccionesRepository _transRepo;
        private readonly EcoConectaDbContext _context;

        public CalificacionesService(ICalificacionesRepository repo, ITransaccionesRepository transRepo, EcoConectaDbContext context)
        {
            _repo = repo;
            _transRepo = transRepo;
            _context = context;
        }

        public async Task<int> CrearCalificacionAsync(CalificacionesDTO.CreateCalificacionDTO dto)
        {
            // Validar puntuación
            if (dto.Puntuacion < 1 || dto.Puntuacion > 5) return 0;

            // Validar existencia de transaccion
            var trans = await _transRepo.GetById(dto.IdTransaccion);
            if (trans == null) return 0;

            // Un usuario no puede calificar más de una vez por la misma transacción
            if (await _repo.ExistePorTransaccion(dto.IdTransaccion)) return 0;

            var cal = new Calificaciones
            {
                IdTransaccion = dto.IdTransaccion,
                IdCalificador = dto.IdCalificador,
                IdVendedor = dto.IdVendedor,
                Puntuacion = dto.Puntuacion,
                Comentario = dto.Comentario
            };

            var id = await _repo.Crear(cal);

            // Opcional: actualizar algún cache o notificar al vendedor
            var not = new Notificaciones
            {
                IdPublicacion = trans.IdPublicacion,
                IdUsuario = dto.IdVendedor,
                Mensaje = "Has recibido una nueva calificación",
                Leido = false
            };
            _context.Notificaciones.Add(not);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
