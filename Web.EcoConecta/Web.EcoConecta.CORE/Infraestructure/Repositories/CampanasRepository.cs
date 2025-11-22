using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Infraestructure.Repositories
{
    public class CampanasRepository : ICampanasRepository
    {
        private readonly EcoConectaDbContext _context;
        public CampanasRepository(EcoConectaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Crear(CampanasReciclaje campana)
        {
            await _context.CampanasReciclaje.AddAsync(campana);
            await _context.SaveChangesAsync();
            return campana.IdCampana;
        }

        public async Task<int> Actualizar(CampanasReciclaje campana)
        {
            _context.CampanasReciclaje.Update(campana);
            await _context.SaveChangesAsync();
            return campana.IdCampana;
        }

        public async Task<int> Eliminar(int id)
        {
            var c = await _context.CampanasReciclaje.FindAsync(id);
            if (c == null) return 0;
            _context.CampanasReciclaje.Remove(c);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<CampanasReciclaje>> GetAllActive()
        {
            return await _context.CampanasReciclaje.OrderByDescending(c => c.FechaPublicacion).ToListAsync();
        }
    }
}
