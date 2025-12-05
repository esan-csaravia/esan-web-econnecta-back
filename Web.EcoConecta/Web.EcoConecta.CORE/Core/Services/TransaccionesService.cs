using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Services
{
    public class TransaccionesService : ITransaccionesService
    {
        private readonly ITransaccionesRepository _repo;
        private readonly EcoConectaDbContext _context;

        public TransaccionesService(ITransaccionesRepository repo, EcoConectaDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<int> CrearTransaccionAsync(TransaccionesDTO.CreateTransaccionDTO dto)
        {
            // Validaciones básicas
            var publicacion = await _context.Publicaciones
                .FirstOrDefaultAsync(p => p.IdPublicacion == dto.IdPublicacion);

            if (publicacion == null) return 0;

            // Obtener datos del comprador y vendedor
            var comprador = await _context.Usuarios.FindAsync(dto.IdComprador);
            var vendedor = await _context.Usuarios.FindAsync(dto.IdVendedor);

            var transaccion = new Transacciones
            {
                IdPublicacion = dto.IdPublicacion,
                IdComprador = dto.IdComprador,
                IdVendedor = dto.IdVendedor,
                Tipo = dto.Tipo,
                // Fecha default en DB
            };

            // Guardar transacción
            var id = await _repo.Crear(transaccion);

            var nombreComprador = comprador?.Nombre ?? "Alguien";
            var titulo = publicacion.Titulo ?? "tu publicación";

            // 🔔 Notificación para el VENDEDOR (venta)
            var notVendedor = new Notificaciones
            {
                IdPublicacion = dto.IdPublicacion,
                IdUsuario = dto.IdVendedor,
                Mensaje = $"{nombreComprador} ha comprado tu producto \"{titulo}\".",
                Leido = false,
                Fecha = DateTime.Now
            };

            // 🔔 Notificación para el COMPRADOR (compra)
            var notComprador = new Notificaciones
            {
                IdPublicacion = dto.IdPublicacion,
                IdUsuario = dto.IdComprador,
                Mensaje = $"Has comprado el producto \"{titulo}\".",
                Leido = false,
                Fecha = DateTime.Now
            };

            _context.Notificaciones.AddRange(notVendedor, notComprador);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<IEnumerable<TransaccionesDTO.HistorialDTO>> GetHistorialAsync(int idUsuario)
        {
            var transacciones = await _context.Transacciones
                .Where(t => t.IdComprador == idUsuario || t.IdVendedor == idUsuario)
                .Include(t => t.IdPublicacionNavigation)
                .Select(t => new TransaccionesDTO.HistorialDTO
                {
                    IdTransaccion = t.IdTransaccion,

                    // Si yo soy el comprador → es compra
                    // Si yo soy el vendedor → es venta
                    Tipo = t.IdComprador == idUsuario ? "compra" : "venta",

                    Fecha = t.Fecha ?? DateTime.Now,

                    Titulo = t.IdPublicacionNavigation.Titulo,
                    Precio = t.IdPublicacionNavigation.Precio ?? 0
                })
                .OrderByDescending(t => t.Fecha)
                .ToListAsync();

            return transacciones;
        }

        public async Task<Transacciones?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdDetalle(id);
        }

        public async Task<TransaccionDetalleDTO?> GetDetalleCompraAsync(int id)
        {
            var t = await _repo.GetByIdDetalle(id);
            if (t == null) return null;

            return new TransaccionDetalleDTO
            {
                IdTransaccion = t.IdTransaccion,
                Fecha = t.Fecha,

                Publicacion = new PublicacionDetalleDTO
                {
                    Titulo = t.IdPublicacionNavigation.Titulo,
                    Precio = t.IdPublicacionNavigation.Precio ?? 0,
                    Imagenes = t.IdPublicacionNavigation.ImagenesPublicacion
                        .Select(i => i.RutaImagen)
                        .ToList()
                },

                Vendedor = new UsuarioSimpleDTO
                {
                    IdUsuario = t.IdVendedorNavigation.IdUsuario,
                    Nombre = t.IdVendedorNavigation.Nombre,
                    Apellido = t.IdVendedorNavigation.Apellido
                }
            };
        }
    }
}
