using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;
using static Web.EcoConecta.CORE.Core.DTOs.BloqueosUsuariosDTO;

namespace Web.EcoConecta.CORE.Core.Services
{
    public class BloqueosUsuariosService : IBloqueosUsuariosService
    {
        private readonly IBloqueosUsuariosRepository _repo;
        private readonly EcoConectaDbContext _context;

        public BloqueosUsuariosService(IBloqueosUsuariosRepository repo, EcoConectaDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<int> CrearAsync(BloqueosUsuariosDTO.CreateBloqueoDTO dto)
        {
            var bloqueo = new BloqueosUsuarios
            {
                IdUsuario = dto.IdUsuario,
                IdAdmin = dto.IdAdmin,
                Motivo = dto.Motivo,
                Fecha = DateTime.Now
            };

            // Guarda el bloqueo
            var id = await _repo.CrearAsync(bloqueo);

            // Bloquear usuario (activo = 0)
            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
            if (usuario != null)
            {
                usuario.Activo = false;
                await _context.SaveChangesAsync();
            }

            return id;
        }


        public async Task<IEnumerable<BloqueosUsuariosDTO.BloqueoListDTO>> GetHistorialAsync(int idUsuario)
        {
            var lista = await _repo.GetByUsuarioAsync(idUsuario);

            return lista.Select(b => new BloqueosUsuariosDTO.BloqueoListDTO
            {
                IdBloqueo = b.IdBloqueo,
                IdUsuario = b.IdUsuario,
                IdAdmin = b.IdAdmin,
                Motivo = b.Motivo,
                Fecha = b.Fecha,
                NombreUsuario = $"{b.IdUsuarioNavigation?.Nombre} {b.IdUsuarioNavigation?.Apellido}",
                NombreAdmin = $"{b.IdAdminNavigation?.Nombre} {b.IdAdminNavigation?.Apellido}"
            });
        }

        public async Task<int> CrearBloqueo(CreateBloqueoDTO dto)
        {
            var bloqueo = new BloqueosUsuarios
            {
                IdUsuario = dto.IdUsuario,
                IdAdmin = dto.IdAdmin,
                Motivo = dto.Motivo,
                Fecha = DateTime.Now
            };

            _context.BloqueosUsuarios.Add(bloqueo);

            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
            usuario.Activo = false;  // ← AQUÍ LO BLOQUEAS

            await _context.SaveChangesAsync();

            return bloqueo.IdBloqueo;
        }

    }
}
