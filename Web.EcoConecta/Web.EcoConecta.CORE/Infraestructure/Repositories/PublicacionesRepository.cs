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
    public class PublicacionesRepository : IPublicacionesRepository
    {
        private readonly EcoConectaDbContext _context;
        public PublicacionesRepository(EcoConectaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Crear(Publicaciones pub)
        {
            await _context.Publicaciones.AddAsync(pub);
            await _context.SaveChangesAsync();
            return pub.IdPublicacion;
        }

        public async Task<int> Actualizar(Publicaciones pub)
        {
            _context.Publicaciones.Update(pub);
            await _context.SaveChangesAsync();
            return pub.IdPublicacion;
        }

        public async Task<int> Eliminar(int id)
        {
            var pub = await _context.Publicaciones.FindAsync(id);
            if (pub == null) return 0;
            _context.Publicaciones.Remove(pub);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<Publicaciones> GetById(int id)
        {
            return await _context.Publicaciones.Include(p => p.ImagenesPublicacion).FirstOrDefaultAsync(p => p.IdPublicacion == id);
        }

        public async Task<IEnumerable<Publicaciones>> GetPendientes()
        {
            return await _context.Publicaciones.Where(p => p.EstadoPublicacion == "pendiente").Include(p => p.ImagenesPublicacion).ToListAsync();
        }

        public async Task<IEnumerable<Publicaciones>> Buscar(string? titulo, int? categoria, string? distrito)
        {
            var query = _context.Publicaciones.AsQueryable();
            if (!string.IsNullOrWhiteSpace(titulo)) query = query.Where(p => p.Titulo.Contains(titulo));
            if (categoria.HasValue) query = query.Where(p => p.IdCategoria == categoria.Value);
            if (!string.IsNullOrWhiteSpace(distrito)) query = query.Where(p => p.IdUsuarioNavigation.Distrito == distrito);
            return await query.Include(p => p.ImagenesPublicacion).ToListAsync();
        }

        public async Task<IEnumerable<Publicaciones>> BuscarAprobadas(string? titulo, int? categoria, string? distrito)
        {
            var query = _context.Publicaciones
                .Where(p => p.EstadoPublicacion == "aprobada")
                .Include(p => p.ImagenesPublicacion)
                .Include(p => p.IdUsuarioNavigation)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(titulo))
                query = query.Where(p => p.Titulo.Contains(titulo));

            if (categoria.HasValue)
                query = query.Where(p => p.IdCategoria == categoria.Value);

            if (!string.IsNullOrWhiteSpace(distrito))
                query = query.Where(p => p.IdUsuarioNavigation.Distrito == distrito);

            return await query.ToListAsync();
        }

        public async Task<Publicaciones> GetDetalle(int id)
        {
            return await _context.Publicaciones
                .Include(p => p.ImagenesPublicacion)
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.Comentarios).ThenInclude(c => c.IdUsuarioNavigation)
                .Include(p => p.IdCategoriaNavigation)
                .FirstOrDefaultAsync(p => p.IdPublicacion == id);
        }


    }

}
