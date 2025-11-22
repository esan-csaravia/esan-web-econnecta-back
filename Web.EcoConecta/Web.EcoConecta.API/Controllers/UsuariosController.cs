using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.EcoConecta.CORE.Core.Interfaces;
using Web.EcoConecta.CORE.Core.DTOs;

namespace Web.EcoConecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuariosService.GetUsuariosAsync();
            return Ok(usuarios);
        }

        // GET: api/usuarios/{id}/profile
        [HttpGet("{id}/profile")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var perfil = await _usuariosService.GetUsuarioProfileAsync(id);
            if (perfil == null) return NotFound();
            return Ok(perfil);
        }

        // GET: api/usuarios/{id}/score
        [HttpGet("{id}/score")]
        public async Task<IActionResult> GetScore(int id)
        {
            var score = await _usuariosService.GetUserScoreAsync(id);
            return Ok(score);
        }

        // POST: api/usuarios  (registro)
        [HttpPost("registro")]
        public async Task<IActionResult> Register([FromBody] UsuariosDTO.CreateUsuarioDTO dto)
        {
            if (dto == null) return BadRequest();
            if (string.IsNullOrWhiteSpace(dto.Correo) || string.IsNullOrWhiteSpace(dto.Contrasena)) return BadRequest("Correo y contraseña son requeridos.");
            if (dto.Contrasena.Length < 8) return BadRequest("La contraseña debe tener al menos 8 caracteres.");

            // validar correo no registrado
            var usuarios = await _usuariosService.GetUsuariosAsync();
            if (usuarios.Any(u => string.Equals(u.Correo, dto.Correo, StringComparison.OrdinalIgnoreCase)))
            {
                return Conflict("El correo ya está registrado.");
            }

            var id = await _usuariosService.CrearAsync(dto);
            if (id == 0) return BadRequest();

            // Devolver ubicación del recurso (profile)
            return CreatedAtAction(nameof(GetProfile), new { id = id }, new { Id = id });
        }

        // POST: api/usuarios/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuariosDTO.LoginDTO dto)
        {
            if (dto == null) return BadRequest();
            var usuario = await _usuariosService.LoginAsync(dto);
            if (usuario == null) return Unauthorized("Credenciales inválidas.");
            return Ok(usuario);
        }

        // PUT: api/usuarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuariosDTO.UpdateUsuarioDTO dto)
        {
            if (dto == null) return BadRequest();
            var res = await _usuariosService.ActualizarAsync(id, dto);
            if (res == 0) return NotFound();
            return Ok(new { Id = res });
        }

        // DELETE: api/usuarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _usuariosService.EliminarAsync(id);
            if (res == 0) return NotFound();
            return Ok(new { Id = res });
        }
    }
}
