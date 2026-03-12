using FluentValidation;

namespace src.Modules.Academic.App.MataKuliah.Commands.Tugas.TandaiStatus.TandaiTugasBelumDikumpul;

public class TandaiTugasBelumDikumpulCommandValidator : AbstractValidator<TandaiTugasBelumDikumpulCommand>
{
    public TandaiTugasBelumDikumpulCommandValidator()
    {
        RuleFor(x => x.MataKuliahId)
            .NotEmpty();
            
        RuleFor(x => x.MateriId)
            .NotEmpty();

        RuleFor(x => x.TugasId)
            .NotEmpty();
    }
}