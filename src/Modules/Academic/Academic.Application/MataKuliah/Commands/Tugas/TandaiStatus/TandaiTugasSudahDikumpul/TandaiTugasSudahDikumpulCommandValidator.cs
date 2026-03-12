using FluentValidation;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.TandaiStatus.TandaiTugasSudahDikumpul;

public class TandaiTugasSudahDikumpulCommandValidator : AbstractValidator<TandaiTugasSudahDikumpulCommand>
{
    public TandaiTugasSudahDikumpulCommandValidator()
    {
        RuleFor(x => x.MataKuliahId)
            .NotEmpty();
            
        RuleFor(x => x.MateriId)
            .NotEmpty();

        RuleFor(x => x.TugasId)
            .NotEmpty();
    }
}