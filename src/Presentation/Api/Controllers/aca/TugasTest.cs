// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using src.Modules.Academic.App.MataKuliah.Commands.Tugas.TambahTugas;
// using src.Modules.Academic.App.MataKuliah.Queries.Tugas.GetTugasDetail;
// using src.Modules.Academic.App.MataKuliah.Queries.Tugas.GetTugasMetadataList;

// namespace src.Api.Controllers.Academic;

// [ApiController]
// [Route("api/[controller]")]
// public class TugasController : ControllerBase
// {
//     private readonly ISender _sender;

//     public TugasController(ISender sender)
//     {
//         _sender = sender;
//     }

//     [HttpPost("tambah")]
//     public async Task<IActionResult> Tambah(
//         TambahTugasCommand commad,
//         CancellationToken cancellationToken)
//     {
//         var res = await _sender.Send(
//             commad, cancellationToken
//         );

//         return res.IsFailure
//             ? BadRequest(res.Error)
//             : Ok(res.Value);
//     }  

//     [HttpGet("{TugasId:guid}")]
//     public async Task<IActionResult> Ambil(
//         Guid MateriId,
//         Guid TugasId,
//         CancellationToken cancellationToken)
//     {
//         var res = await _sender.Send(
//             new GetTugasDetailQuery(MateriId, TugasId), cancellationToken
//         );

//         return res.IsFailure
//             ? BadRequest(res.Error)
//             : Ok(res.Value);
//     }     

//     [HttpGet("{MateriId:guid}/all")]
//     public async Task<IActionResult> AmbilSemua(
//         Guid MateriId,
//         CancellationToken cancellationToken)
//     {
//         var res = await _sender.Send(
//             new GetTugasMetadataListQuery(MateriId), cancellationToken
//         );

//         return res.IsFailure
//             ? BadRequest(res.Error)
//             : Ok(res.Value);
//     }
// }