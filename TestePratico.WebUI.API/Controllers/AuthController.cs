using Microsoft.AspNetCore.Mvc;
using TestePratico.Application.Interfaces;
using TestePratico.Application.ViewModels;
using TestePratico.WebUI.API.Configurations;

namespace TestePratico.WebUI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Autenticar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = await _usuarioService.Login(usuarioViewModel);

            if (usuario == null)
            {
                return NotFound();
            }

            var token = new GeracaoToken().GerarToken(usuario);

            return Ok(token);
        }
    }
}
