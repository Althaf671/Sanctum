using FluentValidation;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Tugas.RevisiInfoTugas;

public class RevisiInfoTugasCommandValidator : AbstractValidator<RevisiInfoTugasCommand>
{
    public RevisiInfoTugasCommandValidator()
    {
        RuleFor(x => x.MateriId)
            .NotEmpty();

        RuleFor(x => x.TugasId)
            .NotEmpty();
    }
}