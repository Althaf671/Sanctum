using MediatR;
using Microsoft.EntityFrameworkCore;
using src.App.Common.Interfaces;
using src.Domain.Common;
using src.Domain.Errors.EntityErrors;
using src.Domain.ValueObjects;

namespace src.App.Features.ModuleKuliah.Semester.Commands.RevisiInfoSemester;

internal sealed class RevisiInfoSemesterCommandHandler
    : IRequestHandler<RevisiInfoSemesterCommand, Result>
{
    private readonly IApplicationDbContext _dbContext;

    public RevisiInfoSemesterCommandHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Result> Handle(RevisiInfoSemesterCommand request, CancellationToken cancellationToken)
    {
        var masaKuliah = MasaKuliah.Create(request.SemesterPeriod, request.Tahun);
        if (masaKuliah.IsFailure)
            return Result.Failure(masaKuliah.Error);

        var semester = await _dbContext.Semester.FindAsync([request.SemesterId], cancellationToken: cancellationToken);
        if (semester is null)
            return Result.Failure(SemesterErrors.SemesterWithIdNotFound(request.SemesterId));

        var newInfoSemester = semester.RevisiInfoSemester(masaKuliah.Value!, request.TahunAjaran);
        if (newInfoSemester.IsFailure)
            return Result.Failure(newInfoSemester.Error);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}