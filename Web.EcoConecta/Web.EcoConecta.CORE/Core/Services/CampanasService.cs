using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Entities;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Infraestructure.Data;

namespace Web.EcoConecta.CORE.Core.Services
{
    public class CampanasService : ICampanasService
    {
        private readonly ICampanasRepository _repo;
        private readonly EcoConectaDbContext _context;

        public CampanasService(ICampanasRepository repo, EcoConectaDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<int> CrearCampanaAsync(CampanaDTO.CreateCampanaDTO dto)
        {
            var c = new CampanasReciclaje
            {
                IdAdmin = dto.IdAdmin,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Imagen = dto.Imagen,
                FechaCampana = DateOnly.FromDateTime(DateTime.Now) // o dto.FechaCampana
            };

            return await _repo.Crear(c);
        }

        public async Task<IEnumerable<CampanaDTO.CampanaListDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllActive();
            return list.Select(c => new CampanaDTO.CampanaListDTO
            {
                IdCampana = c.IdCampana,
                IdAdmin = c.IdAdmin,
                Titulo = c.Titulo,
                Descripcion = c.Descripcion,
                Imagen = c.Imagen,
                FechaPublicacion = c.FechaPublicacion
            });
        }
    }
}
