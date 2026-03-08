using FluentValidation;

namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.TandaiMateriSudahDibaca;

public class TandaiMateriSudahDibacaCommandValidator 
    : AbstractValidator<TandaiMateriSudahDibacaCommand>
{
    public TandaiMateriSudahDibacaCommandValidator()
    {
        RuleFor(x => x.MateriId)
            .NotEmpty();
    }
}