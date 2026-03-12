using FluentValidation;

namespace src.Modules.Academic.App.Jurusan.Commands.DaftarkanJurusan;

public class DaftarkanJurusanCommandValidator : AbstractValidator<DaftarkanJurusanCommand>
{
    public DaftarkanJurusanCommandValidator()
    {
        RuleFor(x => x.Jenjang)
            .IsInEnum().WithMessage("Pilih salah satu Jenjang!");

        RuleFor(x => x.Akreditasi)
            .IsInEnum().WithMessage("Pilih salah satu Akreditasi!");
    }
}