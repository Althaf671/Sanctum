using FluentValidation;

namespace src.Modules.Academic.App.MataKuliah.Commands.Materi.TambahMateri;

public class TambahMateriCommandValidation : AbstractValidator<TambahMateriCommand>
{
    public TambahMateriCommandValidation()
    {
        RuleFor(x => x.MataKuliahId)
            .NotEmpty();
            
        RuleFor(x => x.TipeMateri)
            .IsInEnum().WithMessage("Pilih salah satu tipe materi!");
    }
}