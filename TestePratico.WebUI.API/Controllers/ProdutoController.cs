using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestePratico.Application.Interfaces;
using TestePratico.Application.ViewModels;

namespace TestePratico.WebUI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService) 
        {
            _produtoService = produtoService;                    
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _produtoService.Inserir(produtoViewModel);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _produtoService.Inserir(produtoViewModel);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await _produtoService.Buscar();
            return Ok(resultado);
        }
    }
}
