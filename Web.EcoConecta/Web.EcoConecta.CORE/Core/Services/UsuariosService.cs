using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Core.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _repository;
        private readonly EcoConectaDbContext _context;

        public UsuariosService(IUsuariosRepository repository, EcoConectaDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<UsuariosDTO.UsuariosListDTO>> GetUsuariosAsync()
        {
            var usuarios = await _repository.GetUsuarios();
            return usuarios.Select(u => new UsuariosDTO.UsuariosListDTO
            {
                IdUsuario = u.IdUsuario,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo
            });
        }

        public async Task<UsuariosDTO.UserProfileDTO?> GetUsuarioProfileAsync(int id)
        {
            var usuario = await _repository.GetUsuarioById(id);
            if (usuario == null) return null;

            // Calcular puntuación promedio y totales usando consultas directas al DbContext
            var calificacionesQuery = _context.Calificaciones.Where(c => c.IdVendedor == id);
            var totalCalificaciones = await calificacionesQuery.CountAsync();
            double promedio = 0;
            if (totalCalificaciones > 0)
            {
                promedio = await calificacionesQuery.AverageAsync(c => (double)c.Puntuacion);
            }

            var totalVentas = await _context.Transacciones.CountAsync(t => t.IdVendedor == id);
            var totalCompras = await _context.Transacciones.CountAsync(t => t.IdComprador == id);

            return new UsuariosDTO.UserProfileDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                Distrito = usuario.Distrito,
                PuntuacionPromedio = Math.Round(promedio, 2),
                TotalCalificaciones = totalCalificaciones,
                TotalVentas = totalVentas,
                TotalCompras = totalCompras,
                FechaRegistro = usuario.FechaRegistro ?? DateTime.Now // <-- AGREGADO
            };

        }

        public async Task<int> CrearAsync(UsuariosDTO.CreateUsuarioDTO dto)
        {
            var usuario = new Usuarios
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Correo = dto.Correo,
                Distrito = dto.Distrito,
                Contrasena = dto.Contrasena,
                Activo = true
            };

            return await _repository.Crear(usuario);
        }

        public async Task<int> ActualizarAsync(int id, UsuariosDTO.UpdateUsuarioDTO dto)
        {
            var usuario = await _repository.GetUsuarioById(id);
            if (usuario == null) return 0;

            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Correo = dto.Correo;
            usuario.Distrito = dto.Distrito;

            return await _repository.Actualizar(usuario);
        }

        public async Task<int> EliminarAsync(int id)
        {
            return await _repository.Eliminar(id);
        }

        public async Task<UsuariosDTO.UsuariosListDTO?> LoginAsync(UsuariosDTO.LoginDTO dto)
        {
            var usuario = await _repository.Login(dto.Correo, dto.Contrasena);
            if (usuario == null) return null;

            return new UsuariosDTO.UsuariosListDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo
            };
        }

        public async Task<UsuariosDTO.UserScoreDTO> GetUserScoreAsync(int id)
        {
            var calificacionesQuery = _context.Calificaciones.Where(c => c.IdVendedor == id);
            var cantidad = await calificacionesQuery.CountAsync();
            double promedio = 0;
            if (cantidad > 0)
            {
                promedio = await calificacionesQuery.AverageAsync(c => (double)c.Puntuacion);
            }

            return new UsuariosDTO.UserScoreDTO
            {
                IdUsuario = id,
                Promedio = Math.Round(promedio, 2),
                CantidadCalificaciones = cantidad
            };
        }

        public async Task<IEnumerable<string>> GetDistritosAsync()
        {
            return await _repository
                .GetAll()
                .Where(u => !string.IsNullOrWhiteSpace(u.Distrito))
                .Select(u => u.Distrito)
                .Distinct()
                .ToListAsync();
        }

        public async Task<int> CountVendidosAsync(int idUsuario)
        {
            return await _context.Transacciones
                .CountAsync(t => t.IdVendedor == idUsuario && t.Tipo == "compra");
        }

        public async Task<int> CountCompradosAsync(int idUsuario)
        {
            return await _context.Transacciones
                .CountAsync(t => t.IdComprador == idUsuario);
        }

        public async Task<(bool Exito, string Mensaje)> CambiarPasswordAsync(int id, UsuariosDTO.CambiarPasswordDTO dto)
        {
            var user = await _repository.GetUsuarioById(id);
            if (user == null)
                return (false, "Usuario no encontrado.");

            // Validar contraseña actual
            if (user.Contrasena != dto.PasswordActual)
                return (false, "La contraseña actual es incorrecta.");

            if (dto.NuevaPassword.Length < 8)
                return (false, "La nueva contraseña debe tener al menos 8 caracteres.");

            user.Contrasena = dto.NuevaPassword;

            await _repository.Actualizar(user);

            return (true, "OK");
        }


    }
}
