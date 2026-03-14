using MediatR;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Academic.App.Jurusan.Commands.DaftarkanJurusan;
using src.Modules.Academic.App.Jurusan.Commands.RevisiInfoJurusan;
using src.Modules.Academic.App.Jurusan.Queries.GetDetailJurusan;
using Microsoft.AspNetCore.Http;

namespace src.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JurusanController : ControllerBase
{
    private readonly ISender _sender;
    
    private readonly IFormFile _formFile;

    public JurusanController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("daftarkan")]
    public async Task<IActionResult> DaftarkanJurusan(
        DaftarkanJurusanCommand command,
        CancellationToken cancellationToken)
    {
        var res = await _sender.Send(command, cancellationToken);

        return res.IsFailure
            ? BadRequest(res.Error)
            : Ok($"Berhasil mendaftarkan jurusan dengan ID: {res.Value}");
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> TampilkanDetailJurusan(
        Guid id,
        CancellationToken cancellationToken)
    {
        var res = await _sender.Send(
            new GetDetailJurusanQuery(id), cancellationToken);

        return res.IsFailure
            ? BadRequest(res.Error)
            : Ok(res.Value);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> RevisiInfoJurusan(
        Guid id, 
        RevisiInfoJurusanCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(
            command with { JurusanId = id }, cancellationToken);

        return result.IsFailure
            ? BadRequest(result.Error)
            : Ok("Berhasil update info jurusan");
    }
}