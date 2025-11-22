using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EcoConecta.CORE.Core.DTOs
{
    public class UsuariosDTO
    {
        public class UsuariosListDTO
        {
            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Correo { get; set; }
        }

        public class CreateUsuarioDTO
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Correo { get; set; }
            public string Distrito { get; set; }
            public string Contrasena { get; set; }
        }

        public class UpdateUsuarioDTO
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Correo { get; set; }
            public string Distrito { get; set; }
        }

        public class LoginDTO
        {
            public string Correo { get; set; }
            public string Contrasena { get; set; }
        }

        public class ForgotPasswordDTO
        {
            public string Correo { get; set; }
        }

        public class ResetPasswordDTO
        {
            public string Token { get; set; }   // token enviado por correo
            public string NuevaContrasena { get; set; }
        }

        public class UserProfileDTO
        {
            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Correo { get; set; }
            public string Distrito { get; set; }

            // Puntuación y estadísticas
            public double PuntuacionPromedio { get; set; }
            public int TotalCalificaciones { get; set; }
            public int TotalVentas { get; set; }
            public int TotalCompras { get; set; }
        }

        public class UserScoreDTO
        {
            public int IdUsuario { get; set; }
            public double Promedio { get; set; }
            public int CantidadCalificaciones { get; set; }
        }

        public class BlockUserDTO
        {
            public int IdUsuario { get; set; }
            public string Motivo { get; set; }
        }
    }
}
