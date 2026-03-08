using FluentValidation;

namespace src.App.Features.ModuleKuliah.Jurusan.Commands.DaftarkanJurusan;

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