using MediatR;
using src.App.Common.Interfaces;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.SharedKernel.Domain.Common;

namespace src.Modules.Academic.App.Jurusan.Commands.RevisiInfoJurusan;

internal sealed class RevisiInfoJurusanCommandHandler
    : IRequestHandler<RevisiInfoJurusanCommand, Result>
{
    private readonly IApplicationDbContext _dbContext;

    public RevisiInfoJurusanCommandHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result> Handle(RevisiInfoJurusanCommand request, CancellationToken cancellationToken)
    {
        var jurusan = await _dbContext.Jurusan.FindAsync([request.JurusanId], cancellationToken);
        if (jurusan is null)
            return Result.Failure(JurusanErrors.JurusanWithIdNotFound(request.JurusanId));

        var result = jurusan.RevisiInfoJurusan(
            request.KodeJurusan,
            request.NamaJurusan,
            request.NamaFakultas,
            request.Jenjang,
            request.Akreditasi
        );
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}