using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Core.Interfaces
{
    public interface ICategoriasRepository
    {
        Task<int> Create(Categorias categoria);
        Task<int> Delete(int id);
        Task<IEnumerable<Categorias>> GetAll();
        Task<Categorias?> GetById(int id);
        Task<int> Update(Categorias categoria);
    }
}