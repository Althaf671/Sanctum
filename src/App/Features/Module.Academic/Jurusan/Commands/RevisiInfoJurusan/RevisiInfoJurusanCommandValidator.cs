using FluentValidation;
using src.App.Features.ModuleKuliah.Jurusan.Commands.DaftarkanJurusan;

namespace src.App.Features.ModuleKuliah.Jurusan.Commands.RevisiInfoJurusan;

public class RevisiInfoJurusanCommandValidator : AbstractValidator<RevisiInfoJurusanCommand>
{
    public RevisiInfoJurusanCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Jenjang)
            .IsInEnum().WithMessage("Pilih salah satu Jenjang!");

        RuleFor(x => x.Akreditasi)
            .IsInEnum().WithMessage("Pilih salah satu Akreditasi!");
    }
}