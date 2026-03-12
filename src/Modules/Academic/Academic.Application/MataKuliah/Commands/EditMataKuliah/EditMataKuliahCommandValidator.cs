using FluentValidation;

namespace src.Modules.Academic.App.MataKuliah.Commands.EditMataKuliah;

public class EditMataKuliahCommandValidator : AbstractValidator<EditMataKuliahCommand>
{
    public EditMataKuliahCommandValidator()
    {
        RuleFor(x => x.MataKuliahId)
            .NotEmpty();
    }
}
