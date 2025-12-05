using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface IUsuariosService
    {
        Task<int> ActualizarAsync(int id, UsuariosDTO.UpdateUsuarioDTO dto);
        Task<(bool Exito, string Mensaje)> CambiarPasswordAsync(int id, UsuariosDTO.CambiarPasswordDTO dto);
        Task<int> CountCompradosAsync(int idUsuario);
        Task<int> CountVendidosAsync(int idUsuario);
        Task<int> CrearAsync(UsuariosDTO.CreateUsuarioDTO dto);
        Task<int> EliminarAsync(int id);
        Task<IEnumerable<string>> GetDistritosAsync();
        Task<UsuariosDTO.UserScoreDTO> GetUserScoreAsync(int id);
        Task<UsuariosDTO.UserProfileDTO?> GetUsuarioProfileAsync(int id);
        Task<IEnumerable<UsuariosDTO.UsuariosListDTO>> GetUsuariosAsync();
        Task<UsuariosDTO.UsuariosListDTO?> LoginAsync(UsuariosDTO.LoginDTO dto);
    }
}