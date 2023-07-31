using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestePratico.Application.Interfaces;
using TestePratico.Application.ViewModels;

namespace TestePratico.WebUI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(ClienteViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clienteService.Inserir(usuario);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(ClienteViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clienteService.Atualizar(usuario);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Buscar()
        {
            var resposta = await _clienteService.Buscar();
            return Ok(resposta);
        }
    }
}
