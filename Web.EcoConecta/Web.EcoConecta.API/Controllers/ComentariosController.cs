using Microsoft.AspNetCore.Mvc;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentariosService _service;

        public ComentariosController(IComentariosService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ComentariosDTO.CreateComentarioDTO dto)
        {
            var id = await _service.CrearComentarioAsync(dto);
            if (id == 0) return BadRequest();
            return Ok(id);
        }

        [HttpGet("publicacion/{idPublicacion}")]
        public async Task<IActionResult> GetByPublicacion(int idPublicacion)
        {
            var res = await _service.GetByPublicacionAsync(idPublicacion);
            return Ok(res);
        }
    }
}
