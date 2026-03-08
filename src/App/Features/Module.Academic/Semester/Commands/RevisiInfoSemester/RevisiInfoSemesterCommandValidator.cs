using FluentValidation;

namespace src.App.Features.ModuleKuliah.Semester.Commands.RevisiInfoSemester;
public class RevisiInfoSemesterCommandValidator : AbstractValidator<RevisiInfoSemesterCommand>
{
    public RevisiInfoSemesterCommandValidator()
    {
        RuleFor(x => x.SemesterId)
            .NotEmpty();
            
        RuleFor(x => x.SemesterPeriod)
            .IsInEnum().WithMessage("Pilih salah satu antara semester Ganjil atau Genap!");

        RuleFor(x => x.Tahun)
            .NotEmpty().WithMessage("Masukan tahun!");
    }
}