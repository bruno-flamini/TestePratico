using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestePratico.Application.Interfaces;
using TestePratico.Application.ViewModels;

namespace TestePratico.WebUI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usuarioService.Inserir(usuario);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usuarioService.Atualizar(usuario);
            return Ok();
        }

        [HttpGet("{usuarioId:int}")]
        public async Task<IActionResult> Buscar(int usuarioId)
        {
            var resposta = await _usuarioService.Buscar(usuarioId);
            return Ok(resposta);
        }
    }
}
