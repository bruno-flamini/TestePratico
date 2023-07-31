using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestePratico.Application.Interfaces;
using TestePratico.Application.ViewModels;

namespace TestePratico.WebUI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost]
        public async Task<IActionResult> InserirVenda(VendaViewModel vendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _vendaService.InserirVenda(vendaViewModel);
            return Ok();
        }
    }
}
