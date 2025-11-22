using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<int> Actualizar(Usuarios usuarios);
        Task<int> Crear(Usuarios usuarios);
        Task<int> Eliminar(int id);
        Task<Usuarios> GetUsuarioById(int id);
        Task<IEnumerable<Usuarios>> GetUsuarios();
        Task<Usuarios> Login(string correo, string contrasena);
    }
}