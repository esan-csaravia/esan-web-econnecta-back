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
    public class CategoriasService : ICategoriasService
    {
        private readonly ICategoriasRepository _repo;

        public CategoriasService(ICategoriasRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CategoriasDTO.CategoriaListDTO>> GetAll()
        {
            var datos = await _repo.GetAll();
            return datos.Select(c => new CategoriasDTO.CategoriaListDTO
            {
                IdCategoria = c.IdCategoria,
                Nombre = c.Nombre
            });
        }

        public async Task<int> Create(CategoriasDTO.CategoriaCreateDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre)) return 0;

            var cat = new Categorias
            {
                Nombre = dto.Nombre
            };

            return await _repo.Create(cat);
        }

        public async Task<int> Update(int id, CategoriasDTO.CategoriaCreateDTO dto)
        {
            var entity = await _repo.GetById(id);
            if (entity != null)
            {
                entity.Nombre = dto.Nombre;
                return await _repo.Update(entity);
            }

            return 0;
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.Delete(id);
        }
    }
}
