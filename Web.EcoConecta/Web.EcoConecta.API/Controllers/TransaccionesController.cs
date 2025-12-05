using Microsoft.AspNetCore.Mvc;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private readonly ITransaccionesService _service;

        public TransaccionesController(ITransaccionesService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] TransaccionesDTO.CreateTransaccionDTO dto)
        {
            var id = await _service.CrearTransaccionAsync(dto);
            if (id == 0) return BadRequest();
            return Ok(id);
        }

        [HttpGet("historial/{idUsuario}")]
        public async Task<IActionResult> Historial(int idUsuario)
        {
            var res = await _service.GetHistorialAsync(idUsuario);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalle(int id)
        {
            var detalle = await _service.GetDetalleCompraAsync(id);
            if (detalle == null) return NotFound();

            return Ok(detalle);
        }



    }
}
