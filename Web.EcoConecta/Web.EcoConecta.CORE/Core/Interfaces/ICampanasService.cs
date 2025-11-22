using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface ICampanasService
    {
        Task<int> CrearCampanaAsync(CampanaDTO.CreateCampanaDTO dto);
        Task<IEnumerable<CampanaDTO.CampanaListDTO>> GetAllAsync();
    }
}