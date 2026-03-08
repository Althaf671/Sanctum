using FluentValidation;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.GantiIsiMateri;

public class GantiIsiMateriCommandValidator : AbstractValidator<GantiIsiMateriCommand>
{
    public GantiIsiMateriCommandValidator()
    {
        RuleFor(x => x.MateriId)
            .NotEmpty();
    }
}