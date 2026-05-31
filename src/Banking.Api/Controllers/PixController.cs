using Banking.Application.Commands;
using Banking.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Api.Controllers;

[ApiController]
[Route("api/pix")]
public sealed class PixController : ControllerBase
{
    private readonly PixService _pixService;

    public PixController(PixService pixService)
    {
        _pixService = pixService;
    }

    [HttpPost]
    public async Task<IActionResult> RealizarPix([FromBody] RealizarPixCommand command)
    {
        await _pixService.RealizarPixAsync(command);

        return Accepted(new
        {
            Mensagem = "PIX solicitado com sucesso. Evento publicado no RabbitMQ."
        });
    }
}
