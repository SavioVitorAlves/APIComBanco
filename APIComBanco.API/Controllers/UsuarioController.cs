using APIComBanco.API.Domain.Interfaces;
using APIComBanco.API.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIComBanco.API.Controllers
{
    [ApiController]
    [Route("api/v1/usuarios")]
    public class UsuarioController(IUsuarioRepository usuarioRepository) : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        [Authorize]
        [HttpGet("usuarios")]
        public async Task<ActionResult> GetAllUsuario()
        {
            return Ok(await _usuarioRepository.SelecionarAll());
        }

        [HttpGet("usuarios/{id}")]
        public async Task<ActionResult> GetAllUsuario(int id)
        {
            return Ok(await _usuarioRepository.SelecionarByPk(id));
        }

        [HttpPost("create")]
        public async Task<ActionResult> createUsuario(Usuarios usuario)
        {
            try
            {
                _usuarioRepository.Inserir(usuario);
                return Ok("Usuario cadastrado com sucesso!");
            }
            catch
            {
                return BadRequest("Ocorreu um erro ao salvar o usuario!");
            }
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> updateUsuario([FromBody] Usuarios usuario, int id)
        {
            try
            {
                _usuarioRepository.Alterar(usuario, id);
                return Ok("Usuario atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")] 
        public IActionResult deleteUsuario(int id)
        {
            var sucesso = _usuarioRepository.Excluir(id);

            if (!sucesso)
            {
                // Retorna status 404
                return NotFound("Usuário não encontrado no banco!");
            }

            // Retorna status 200
            return Ok("Usuário removido com sucesso!");
        }

    }
}
