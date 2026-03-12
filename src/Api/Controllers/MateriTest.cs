// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.RevisiInfoMateri;
// using src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.TambahMateri;
// using src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriDetail;
// using src.App.Features.ModuleKuliah.MataKuliah.Queries.Materi.GetMateriMetadataList;

// namespace src.Api.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class MateriController : ControllerBase
// {
//     private readonly ISender _sender;

//     public MateriController(ISender sender)
//     {
//         _sender = sender;
//     }

//     [HttpPost("tambah")]
//     public async Task<IActionResult> Tambah(
//         TambahMateriCommand command,
//         CancellationToken cancellationToken)
//     {
//         var res = await _sender.Send(
//             command, cancellationToken
//         );

//         return res.IsFailure
//             ? BadRequest(res.Error)
//             : Ok (res.Value!);
//     } 

//     [HttpPatch("{id:guid}")]
//     public async Task<IActionResult> Revisi(
//         Guid id,
//         RevisiInfoMateriCommand command,
//         CancellationToken cancellationToken)
//     {
//         var res = await _sender.Send(
//             command , cancellationToken
//         );

//         return res.IsFailure
//             ? BadRequest(res.Error)
//             : Ok ("Berhasil revisi info materi");
//     }
// //   "mataKuliahId": "c9cc1b4a-9afc-41c8-aa06-5ee7b56291f1",
// //   "materiId": "c14b234b-32f8-451b-9b57-01f55b3fb7e9"

//     [HttpGet("{id:guid}")]
//     public async Task<IActionResult> Ambil(
//         Guid id,
//         Guid mataKuliahId,
//         CancellationToken cancellationToken)
//     {
//         var res = await _sender.Send(
//             new GetMaterDetailQuery(id, mataKuliahId), cancellationToken
//         );

//         return res.IsFailure
//             ? BadRequest(res.Error)
//             : Ok (res.Value);
//     }
    
//     [HttpGet("{id:guid}/all")]
//     public async Task<IActionResult> AmbilSemua(
//         Guid id,
//         CancellationToken cancellationToken)
//     {
//         var res = await _sender.Send(
//             new GetMateriMetadataListQuery(id), cancellationToken
//         );

//         return res.IsFailure
//             ? BadRequest(res.Error)
//             : Ok (res.Value);
//     }
// }