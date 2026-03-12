using FluentValidation;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.TambahTugas;

public class TambahTugasCommandValidator : AbstractValidator<TambahTugasCommand>
{
    public TambahTugasCommandValidator()
    {
        RuleFor(x => x.MataKuliahId)
            .NotEmpty();
            
        RuleFor(x => x.MateriId)
            .NotEmpty();
    }
}