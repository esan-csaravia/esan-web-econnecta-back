using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Infraestructure.Repositories
{
    public class ComentariosRepository : IComentariosRepository
    {
        private readonly EcoConectaDbContext _context;
        public ComentariosRepository(EcoConectaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Crear(Comentarios comentario)
        {
            await _context.Comentarios.AddAsync(comentario);
            await _context.SaveChangesAsync();
            return comentario.IdComentario;
        }

        public async Task<IEnumerable<Comentarios>> GetByPublicacion(int idPublicacion)
        {
            return await _context.Comentarios.Where(c => c.IdPublicacion == idPublicacion).Include(c => c.IdUsuarioNavigation).ToListAsync();
        }
    }
}
