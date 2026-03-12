using FluentValidation;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.RevisiInfoTugas;

public class RevisiInfoTugasCommandValidator : AbstractValidator<RevisiInfoTugasCommand>
{
    public RevisiInfoTugasCommandValidator()
    {
        RuleFor(x => x.MataKuliahId)
            .NotEmpty();
            
        RuleFor(x => x.MateriId)
            .NotEmpty();

        RuleFor(x => x.TugasId)
            .NotEmpty();
    }
}