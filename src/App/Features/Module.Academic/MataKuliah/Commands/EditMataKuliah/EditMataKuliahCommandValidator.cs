using FluentValidation;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.EditMataKuliah;

public class EditMataKuliahCommandValidator : AbstractValidator<EditMataKuliahCommand>
{
    public EditMataKuliahCommandValidator()
    {
        RuleFor(x => x.MataKuliahId)
            .NotEmpty();
    }
}
