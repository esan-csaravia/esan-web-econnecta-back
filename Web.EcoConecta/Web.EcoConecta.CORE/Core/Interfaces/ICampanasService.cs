using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface ICampanasService
    {
        Task<int> CrearCampanaAsync(CampanaDTO.CreateCampanaDTO dto);
        Task<int> EditarCampanaAsync(CampanaDTO.CreateCampanaDTO dto);
        Task<bool> EliminarCampanaAsync(int id);
        Task<IEnumerable<CampanaDTO.CampanaListDTO>> GetAllAsync();
    }
}