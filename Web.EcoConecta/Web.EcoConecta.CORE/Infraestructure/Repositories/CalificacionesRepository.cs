using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Infraestructure.Repositories
{
    public class CalificacionesRepository : ICalificacionesRepository
    {
        private readonly EcoConectaDbContext _context;
        public CalificacionesRepository(EcoConectaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Crear(Calificaciones calificacion)
        {
            await _context.Calificaciones.AddAsync(calificacion);
            await _context.SaveChangesAsync();
            return calificacion.IdCalificacion;
        }

        public async Task<bool> ExistePorTransaccion(int idTransaccion)
        {
            return await _context.Calificaciones.AnyAsync(c => c.IdTransaccion == idTransaccion);
        }

        public async Task<IEnumerable<Calificaciones>> GetByVendedor(int idVendedor)
        {
            return await _context.Calificaciones.Where(c => c.IdVendedor == idVendedor).ToListAsync();
        }

        public async Task<IEnumerable<Calificaciones>> GetListaByVendedor(int idVendedor)
        {
            return await _context.Calificaciones
                .Where(c => c.IdVendedor == idVendedor)
                .OrderByDescending(c => c.Fecha)
                .ToListAsync();
        }

    }
}
