using MediatR;
using src.App.Common.Interfaces;
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;
using SemesterEntity = src.Modules.AcademicDomain.Entities.SemesterAggregate.Semester;
namespace src.Modules.Academic.App.Semester.Commands.DaftarkanSemester;

internal sealed class DaftarkanSemesterCommandHandler
    : IRequestHandler<DaftarkanSemesterCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _dbContext;

    public DaftarkanSemesterCommandHandler(IApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Result<Guid>> Handle(DaftarkanSemesterCommand request, CancellationToken cancellationToken)
    {
        var masaKuliah = MasaKuliah.Create(request.SemesterPeriod, request.Tahun);
        if (masaKuliah.IsFailure)
            return Result<Guid>.Failure(masaKuliah.Error);
            
        var semester = SemesterEntity.DaftarkanSemester(masaKuliah.Value!, request.TahunAjaran);
        if (semester.IsFailure)
            return Result<Guid>.Failure(semester.Error);

        await _dbContext.Semester.AddAsync(semester.Value!, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(semester.Value!.Id);
    }
}