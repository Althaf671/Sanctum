using FluentValidation;
using src.Modules.Academic.App.Jurusan.Commands.DaftarkanJurusan;

namespace src.Modules.Academic.App.Jurusan.Commands.RevisiInfoJurusan;

public class RevisiInfoJurusanCommandValidator : AbstractValidator<RevisiInfoJurusanCommand>
{
    public RevisiInfoJurusanCommandValidator()
    {
        RuleFor(x => x.JurusanId)
            .NotEmpty();

        RuleFor(x => x.Jenjang)
            .IsInEnum().WithMessage("Pilih salah satu Jenjang!");

        RuleFor(x => x.Akreditasi)
            .IsInEnum().WithMessage("Pilih salah satu Akreditasi!");
    }
}