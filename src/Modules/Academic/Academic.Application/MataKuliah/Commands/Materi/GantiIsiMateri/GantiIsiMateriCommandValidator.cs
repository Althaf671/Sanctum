using FluentValidation;

namespace src.Modules.Academic.App.MataKuliah.Commands.Materi.GantiIsiMateri;

public class GantiIsiMateriCommandValidator : AbstractValidator<GantiIsiMateriCommand>
{
    public GantiIsiMateriCommandValidator()
    {
        RuleFor(x => x.MataKuliahId)
            .NotEmpty();
            
        RuleFor(x => x.MateriId)
            .NotEmpty();
    }
}