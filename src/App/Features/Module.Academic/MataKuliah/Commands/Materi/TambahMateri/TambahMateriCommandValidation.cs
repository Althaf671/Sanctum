using FluentValidation;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.TambahMateri;

public class TambahMateriCommandValidation : AbstractValidator<TambahMateriCommand>
{
    public TambahMateriCommandValidation()
    {
        RuleFor(x => x.TipeMateri)
            .IsInEnum().WithMessage("Pilih salah satu tipe materi!");
    }
}