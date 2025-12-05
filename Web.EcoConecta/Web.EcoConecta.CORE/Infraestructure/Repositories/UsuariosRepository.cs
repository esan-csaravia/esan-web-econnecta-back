using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Infraestructure.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly EcoConectaDbContext _context;
        public UsuariosRepository(EcoConectaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuarios>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<Usuarios> GetUsuarioById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            return usuario;
        }

        public async Task<int> Crear(Usuarios usuarios)
        {
            await _context.Usuarios.AddAsync(usuarios);
            await _context.SaveChangesAsync();
            return usuarios.IdUsuario;
        }

        public async Task<int> Actualizar(Usuarios usuarios)
        {
            _context.Usuarios.Update(usuarios);
            await _context.SaveChangesAsync();
            return usuarios.IdUsuario;
        }

        public async Task<int> Eliminar(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return usuario.IdUsuario;
            }
            return 0;
        }

        // LOGIN
        public async Task<Usuarios> Login(string correo, string contrasena)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Contrasena == contrasena);
        }

        public IQueryable<Usuarios> GetAll()
        {
            return _context.Usuarios.AsQueryable();
        }

    }
}
