using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Infraestructure.Repositories
{
    public class TransaccionesRepository : ITransaccionesRepository
    {
        private readonly EcoConectaDbContext _context;
        public TransaccionesRepository(EcoConectaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Crear(Transacciones transaccion)
        {
            await _context.Transacciones.AddAsync(transaccion);
            await _context.SaveChangesAsync();
            return transaccion.IdTransaccion;
        }

        public async Task<IEnumerable<Transacciones>> GetByUsuario(int idUsuario)
        {
            return await _context.Transacciones
                .Where(t => t.IdComprador == idUsuario || t.IdVendedor == idUsuario)
                .Include(t => t.IdPublicacionNavigation)
                .ToListAsync();
        }

        public async Task<Transacciones> GetById(int id)
        {
            return await _context.Transacciones.Include(t => t.IdPublicacionNavigation).FirstOrDefaultAsync(t => t.IdTransaccion == id);
        }
    }
}
