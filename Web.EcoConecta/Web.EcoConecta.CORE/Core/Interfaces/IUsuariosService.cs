using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface IUsuariosService
    {
        Task<int> ActualizarAsync(int id, UsuariosDTO.UpdateUsuarioDTO dto);
        Task<int> CrearAsync(UsuariosDTO.CreateUsuarioDTO dto);
        Task<int> EliminarAsync(int id);
        Task<UsuariosDTO.UserScoreDTO> GetUserScoreAsync(int id);
        Task<UsuariosDTO.UserProfileDTO?> GetUsuarioProfileAsync(int id);
        Task<IEnumerable<UsuariosDTO.UsuariosListDTO>> GetUsuariosAsync();
        Task<UsuariosDTO.UsuariosListDTO?> LoginAsync(UsuariosDTO.LoginDTO dto);
    }
}