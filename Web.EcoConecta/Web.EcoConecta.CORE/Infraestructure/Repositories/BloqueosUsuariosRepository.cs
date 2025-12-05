using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Infraestructure.Repositories
{
    public class BloqueosUsuariosRepository : IBloqueosUsuariosRepository
    {
        private readonly EcoConectaDbContext _context;

        public BloqueosUsuariosRepository(EcoConectaDbContext context)
        {
            _context = context;
        }

        public async Task<int> CrearAsync(BloqueosUsuarios bloqueo)
        {
            await _context.BloqueosUsuarios.AddAsync(bloqueo);
            await _context.SaveChangesAsync();
            return bloqueo.IdBloqueo;
        }

        public async Task<IEnumerable<BloqueosUsuarios>> GetByUsuarioAsync(int idUsuario)
        {
            return await _context.BloqueosUsuarios
                .Where(b => b.IdUsuario == idUsuario)
                .Include(b => b.IdUsuarioNavigation)
                .Include(b => b.IdAdminNavigation)
                .OrderByDescending(b => b.Fecha)
                .ToListAsync();
        }
    }
}

