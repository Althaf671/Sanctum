using MediatR;
using Microsoft.AspNetCore.Mvc;
using src.App.Features.ModuleKuliah.Semester.Commands.DaftarkanSemester;
using src.App.Features.ModuleKuliah.Semester.Commands.RevisiInfoSemester;
using src.App.Features.ModuleKuliah.Semester.Queries.GetDetailSemester;

namespace src.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SemesterController : ControllerBase
{
    private readonly ISender _sender;

    public SemesterController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("daftarkan")]
    public async Task<IActionResult> DaftarkanSemester(
        DaftarkanSemesterCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);

        return result.IsFailure
            ? BadRequest(result.Error)
            : Ok($"Berhasil mendaftarkan semester dengan ID: {result.Value}");
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> RevisiInfoSemester(
        Guid id,
        RevisiInfoSemesterCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command with { SemesterId = id }, cancellationToken);

        return result.IsFailure
            ? BadRequest(result.Error)
            : Ok("Berhasil update info semester");
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> TampilkanDetailSemester(
        Guid id,
        CancellationToken cancellationToken)
    {
        var res = await _sender.Send(
            new GetDetailSemesterQuery{ SemesterId = id }, cancellationToken);

        return res.IsFailure
            ? BadRequest(res.Error)
            : Ok(res.Value);
    }
}