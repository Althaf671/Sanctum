using FluentValidation;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.HapusTugas;

public class HapusTugasCommandValidator : AbstractValidator<HapusTugasCommand>
{
    public HapusTugasCommandValidator()
    {
        RuleFor(x => x.MataKuliahId)
            .NotEmpty();
            
        RuleFor(x => x.MateriId)
            .NotEmpty();

        RuleFor(x => x.TugasId)
            .NotEmpty();
    }
}