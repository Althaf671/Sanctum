using FluentValidation;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Tugas.TambahTugas;

public class TambahTugasCommandValidator : AbstractValidator<TambahTugasCommand>
{
    public TambahTugasCommandValidator()
    {
        RuleFor(x => x.MateriId)
            .NotEmpty();
    }
}