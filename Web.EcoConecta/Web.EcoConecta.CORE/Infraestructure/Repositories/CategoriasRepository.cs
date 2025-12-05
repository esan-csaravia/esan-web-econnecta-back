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
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly EcoConectaDbContext _context;

        public CategoriasRepository(EcoConectaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorias>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categorias?> GetById(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<int> Create(Categorias categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria.IdCategoria;
        }

        public async Task<int> Update(Categorias categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria.IdCategoria;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Categorias.FindAsync(id);
            if (entity == null) return 0;

            _context.Categorias.Remove(entity);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
