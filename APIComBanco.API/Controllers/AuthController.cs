using APIComBanco.API.Domain.DTOs;
using APIComBanco.API.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIComBanco.API.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class AuthController(IUsuarioRepository usuarioRepository, IConfiguration configuration) : Controller
    {

        public readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IConfiguration _configuration = configuration;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var usuario = await _usuarioRepository.GetByEmail(login.email);

            if (usuario == null)
                return Unauthorized("E-mail ou senha inválidos");

            // 2. Validar a senha usando BCrypt
            bool senhaValida = BCrypt.Net.BCrypt.Verify(login.senha, usuario.senha);

            if (!senhaValida)
                return Unauthorized("E-mail ou senha inválidos");


            var secret = _configuration.GetSection("JwtSettings:Secret").Value;
            // 3. Gerar o Token
            var token = TokenService.GenerateToken(usuario, secret);

            // 4. Retornar o usuário e o token
            return Ok(new
            {
                usuario = usuario.nome,
                token = token
            });
        }
    }
}
