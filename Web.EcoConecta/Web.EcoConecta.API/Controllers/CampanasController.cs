using Microsoft.AspNetCore.Mvc;
using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Interfaces;

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

        // Crear campaña
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CampanaDTO.CreateCampanaDTO dto)
        {
            var id = await _service.CrearCampanaAsync(dto);
            if (id == 0) return BadRequest();
            return Ok(id);
        }

        // Obtener todas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAllAsync();
            return Ok(res);
        }

        // Editar campaña
        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] CampanaDTO.CreateCampanaDTO dto)
        {
            var result = await _service.EditarCampanaAsync(dto);
            if (result == 0) return NotFound();
            return Ok(result);
        }

        // Eliminar campaña
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var ok = await _service.EliminarCampanaAsync(id);
            if (!ok) return NotFound();
            return Ok(new { mensaje = "Campaña eliminada correctamente" });
        }
    }
}
