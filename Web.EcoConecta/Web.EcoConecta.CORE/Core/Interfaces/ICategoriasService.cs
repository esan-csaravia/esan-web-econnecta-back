using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface ICategoriasService
    {
        Task<int> Create(CategoriasDTO.CategoriaCreateDTO dto);
        Task<int> Delete(int id);
        Task<IEnumerable<CategoriasDTO.CategoriaListDTO>> GetAll();
        Task<int> Update(int id, CategoriasDTO.CategoriaCreateDTO dto);
    }
}