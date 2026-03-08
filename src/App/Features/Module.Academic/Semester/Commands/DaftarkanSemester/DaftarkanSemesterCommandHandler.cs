using MediatR;
using src.App.Common.Interfaces;
using src.Domain.Common;
using src.Domain.ValueObjects;
using SemesterEntity = src.Domain.Entities.SemesterAggregate.Semester;

namespace src.App.Features.ModuleKuliah.Semester.Commands.DaftarkanSemester;

internal sealed class DaftarkanSemesterCommandHandler
    : IRequestHandler<DaftarkanSemesterCommand, Result>
{
    private readonly IApplicationDbContext _dbContext;

    public DaftarkanSemesterCommandHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result> Handle(DaftarkanSemesterCommand request, CancellationToken cancellationToken)
    {
        var masaKuliah = MasaKuliah.Create(request.SemesterPeriod, request.Tahun);
        if (masaKuliah.IsFailure)
            return Result.Failure(masaKuliah.Error);
            
        var semester = SemesterEntity.DaftarkanSemester(masaKuliah.Value!, request.TahunAjaran);
        if (semester.IsFailure)
            return Result.Failure(semester.Error);

        await _dbContext.Semester.AddAsync(semester.Value!, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}