using MediatR;
using src.Domain.Common;
using src.Domain.Errors.EntityErrors;
using src.Domain.Interfaces;
using src.Domain.ValueObjects;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Tugas.TambahTugas;

internal sealed class TambahTugasCommandHandler
    : IRequestHandler<TambahTugasCommand, Result<Guid>>
{
    private readonly IMataKuliahRepository _mataKuliahContext;

    public TambahTugasCommandHandler(IMataKuliahRepository context)
    {
        _mataKuliahContext = context;
    }   

    public async Task<Result<Guid>> Handle(TambahTugasCommand request, CancellationToken cancellationToken)
    {
        var linkPengerjaanTugas = Url.Create(request.UrlLinkPengerjaanTugas);
        if (linkPengerjaanTugas.IsFailure)
            return Result<Guid>.Failure(linkPengerjaanTugas.Error);

        var linkPengumpulanTugas = Url.Create(request.UrlLinkPengumpulanTugas);
        if (linkPengumpulanTugas.IsFailure)
            return Result<Guid>.Failure(linkPengumpulanTugas.Error);

        var mataKuliah = await _mataKuliahContext.GetWithMateriByIdAsync(
            request.MataKuliahId,
            request.MateriId,
            cancellationToken
        );
        if (mataKuliah is null)
            return Result<Guid>
                .Failure(MataKuliahErrors.MataKuliahWithIdNotFound(request.MataKuliahId));

        var result = mataKuliah.TambahTugas(
            request.MateriId,
            request.JudulTugas,
            linkPengerjaanTugas.Value!,
            linkPengumpulanTugas.Value!
        );
        if (result.IsFailure)
            return Result<Guid>.Failure(result.Error);

        await _mataKuliahContext.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(result.Value);
    }
}