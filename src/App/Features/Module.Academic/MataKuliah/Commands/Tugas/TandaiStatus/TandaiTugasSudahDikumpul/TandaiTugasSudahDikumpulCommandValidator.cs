using FluentValidation;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Tugas.TandaiStatus.TandaiTugasSudahDikumpul;

public class TandaiTugasSudahDikumpulCommandValidator : AbstractValidator<TandaiTugasSudahDikumpulCommand>
{
    public TandaiTugasSudahDikumpulCommandValidator()
    {
        RuleFor(x => x.MateriId)
            .NotEmpty();

        RuleFor(x => x.TugasId)
            .NotEmpty();
    }
}