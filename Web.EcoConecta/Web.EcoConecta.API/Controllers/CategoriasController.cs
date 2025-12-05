using Microsoft.AspNetCore.Mvc;
using Web.EcoConecta.CORE.Core.DTOs;
using Web.EcoConecta.CORE.Core.Interfaces;

namespace Web.EcoConecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _service;

        public CategoriasController(ICategoriasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAll();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriasDTO.CategoriaCreateDTO dto)
        {
            var id = await _service.Create(dto);
            if (id == 0) return BadRequest("Nombre inválido");

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriasDTO.CategoriaCreateDTO dto)
        {
            var r = await _service.Update(id, dto);
            if (r == 0) return NotFound();

            return Ok(r);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var r = await _service.Delete(id);
            if (r == 0) return NotFound();

            return Ok(r);
        }
    }
}
