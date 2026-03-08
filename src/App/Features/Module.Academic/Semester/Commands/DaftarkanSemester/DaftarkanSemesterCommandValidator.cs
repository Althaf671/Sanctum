using FluentValidation;

namespace src.App.Features.ModuleKuliah.Semester.Commands.DaftarkanSemester;

public class DaftarkanSemesterCommandValidator : AbstractValidator<DaftarkanSemesterCommand>
{
    public DaftarkanSemesterCommandValidator()
    {
        RuleFor(x => x.SemesterPeriod)
            .IsInEnum().WithMessage("Pilih salah satu antara semester Ganjil atau Genap!");

        RuleFor(x => x.Tahun)
            .NotEmpty().WithMessage("Masukan tahun!");
    }
}