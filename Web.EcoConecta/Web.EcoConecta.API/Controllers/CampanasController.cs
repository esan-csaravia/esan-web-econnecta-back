using Microsoft.AspNetCore.Mvc;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampanasController : ControllerBase
    {
        private readonly ICampanasService _service;

        public CampanasController(ICampanasService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CampanaDTO.CreateCampanaDTO dto)
        {
            var id = await _service.CrearCampanaAsync(dto);
            if (id == 0) return BadRequest();
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAllAsync();
            return Ok(res);
        }
    }
}
