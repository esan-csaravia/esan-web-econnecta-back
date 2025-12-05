using Microsoft.AspNetCore.Mvc;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionesController : ControllerBase
    {
        private readonly ICalificacionesService _service;

        public CalificacionesController(ICalificacionesService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CalificacionesDTO.CreateCalificacionDTO dto)
        {
            var id = await _service.CrearCalificacionAsync(dto);
            if (id == 0) return BadRequest();
            return Ok(id);
        }

        [HttpGet("vendedor/{idVendedor}")]
        public async Task<IActionResult> GetCalificacionesVendedor(int idVendedor)
        {
            var result = await _service.GetCalificacionesVendedorAsync(idVendedor);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("lista/{idVendedor}")]
        public async Task<IActionResult> Lista(int idVendedor)
        {
            var result = await _service.GetListaCalificacionesAsync(idVendedor);
            return Ok(result);
        }


    }
}
