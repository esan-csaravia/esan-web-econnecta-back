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

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            Console.WriteLine("---- DEBUG UPLOAD ----");

            var file = Request.Form.Files.FirstOrDefault();

            if (file == null)
            {
                Console.WriteLine("file = NULL");
                return BadRequest("Archivo inválido (no llegó)");
            }

            Console.WriteLine($"Nombre: {file.FileName}");
            Console.WriteLine($"Tamaño: {file.Length}");

            var folder = Path.Combine("wwwroot", "uploads");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = Path.Combine(folder, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
                await file.CopyToAsync(stream);

            return Ok(new { url = "/uploads/" + fileName });
        }

        [HttpGet("aprobadas")]
        public async Task<IActionResult> Aprobadas([FromQuery] string? titulo, [FromQuery] int? categoria, [FromQuery] string? distrito)
        {
            var res = await _service.BuscarAprobadasAsync(titulo, categoria, distrito);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalle(int id)
        {
            var detalle = await _service.GetDetalleAsync(id);
            if (detalle == null) return NotFound();

            return Ok(detalle);
        }



    }
}
