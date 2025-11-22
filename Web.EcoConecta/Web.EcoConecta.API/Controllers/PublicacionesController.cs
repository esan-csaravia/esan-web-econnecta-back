using Microsoft.AspNetCore.Mvc;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        private readonly IPublicacionesService _service;

        public PublicacionesController(IPublicacionesService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PublicacionesDTO.CreatePublicacionDTO dto)
        {
            var id = await _service.CrearPublicacionAsync(dto);
            if (id == 0) return BadRequest();
            return Ok(id);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string? titulo, [FromQuery] int? categoria, [FromQuery] string? distrito)
        {
            var res = await _service.BuscarAsync(titulo, categoria, distrito);
            return Ok(res);
        }

        [HttpGet("pendientes")]
        public async Task<IActionResult> Pendientes()
        {
            var res = await _service.GetPendientesAsync();
            return Ok(res);
        }

        [HttpPut("estado")]
        public async Task<IActionResult> UpdateEstado([FromBody] PublicacionesDTO.UpdateEstadoDTO dto)
        {
            var r = await _service.UpdateEstadoAsync(dto);
            if (r == 0) return NotFound();
            return Ok(r);
        }
    }
}
