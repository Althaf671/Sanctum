using MediatR;
using Microsoft.AspNetCore.Mvc;
using src.Modules.Academic.App.MataKuliah.Commands.EditMataKuliah;
using src.Modules.Academic.App.MataKuliah.Commands.Materi.TambahMataKuliah;
using src.Modules.Academic.App.MataKuliah.Queries.GetMataKuliahDetail;

namespace src.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatKulController : ControllerBase
{
    private readonly ISender _sender;

    public MatKulController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("Tambah")]
    public async Task<IActionResult> Tambah(
        TambahMataKuliahCommand command,
        CancellationToken cancellationToken)
    {
        var res = await _sender.Send(command, cancellationToken);

        return res.IsFailure
            ? BadRequest(res.Error)
            : Ok($"Berhasil mendaftarkan mata kuliah dengan ID: {res.Value}");
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> TampilkanDetail(
        Guid id,
        CancellationToken cancellationToken)
    {
        var res = await _sender.Send(
            new GetMataKuliahDetailQuery(id), cancellationToken);

        return res.IsFailure
            ? BadRequest(res.Error)
            : Ok(res.Value);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Edit(
        Guid id,
        EditMataKuliahCommand command,
        CancellationToken cancellationToken)
    {
        var res = await _sender.Send(
            command with { MataKuliahId = id }, cancellationToken
        );

        return res.IsFailure
            ? BadRequest(res.Error)
            : Ok ("Berhasil update detail nfo mata kuliah");
    }
}