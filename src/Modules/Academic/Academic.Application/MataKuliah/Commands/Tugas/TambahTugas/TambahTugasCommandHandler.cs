using MediatR;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.Interfaces;
using src.SharedKernel.Domain.Common;
using src.SharedKernel.Domain.ValueObjects;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.TambahTugas;

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