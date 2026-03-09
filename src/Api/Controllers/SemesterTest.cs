using MediatR;
using Microsoft.AspNetCore.Mvc;
using src.App.Features.ModuleKuliah.Semester.Commands.DaftarkanSemester;
using src.App.Features.ModuleKuliah.Semester.Commands.RevisiInfoSemester;

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
            : Ok("Berhasil mendaftarkan semester");
    }

    [HttpPost("edit")]
    public async Task<IActionResult> RevisiInfoSemester(
        RevisiInfoSemesterCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);

        return result.IsFailure
            ? BadRequest(result.Error)
            : Ok("Berhasil update info semester");
    }
}