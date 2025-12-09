using GeradorResumo.Application.DTOs;
using GeradorResumo.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GeradorResumo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        
        [HttpPost("resumo")]
        public async Task<IActionResult> Summarize([FromServices] ISumarryIAUseCase useCase, [FromBody] SummaryRequest request)
        {
            var response = await useCase.Execute(request.Text);

            return Ok(response);
        }
    }
}
