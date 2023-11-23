using API_PIM.Application.Services;
using API_PIM.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API_PIM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authentication(string login, string senha)
        {
            var usuario = new UsuarioDAO(_configuration.GetConnectionString("DefaultConnection")!).AuthenticateUsuario(login, senha);
            if (usuario!= null){
                var token = new TokenServices(_configuration);
                return Ok(token.GenerateToken(usuario));
            }
            return BadRequest ("Credenciais Inválidas.");

        }
    }
}
