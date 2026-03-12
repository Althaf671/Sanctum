using FluentValidation;

namespace src.Modules.Academic.App.MataKuliah.Commands.Materi.RevisiInfoMateri;

public class RevisiInfoMateriCommandValidator : AbstractValidator<RevisiInfoMateriCommand>
{
    public RevisiInfoMateriCommandValidator()
    {
        RuleFor(x => x.MataKuliahId)
            .NotEmpty();
            
        RuleFor(x => x.MateriId)
            .NotEmpty();

        RuleFor(x => x.TipeMateri)
            .IsInEnum().WithMessage("Pilih salah satu tipe materi!");
    }
}