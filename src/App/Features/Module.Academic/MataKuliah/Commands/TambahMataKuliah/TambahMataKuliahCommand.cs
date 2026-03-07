using MediatR;
using src.Domain.Common;


namespace src.App.Features.ModuleKuliah.MataKuliah.Commands.Materi.TambahMataKuliah;

public record TambahMataKuliahCommand : IRequest<Result>
{
    public string KodeMataKuliah { get; init; } = null!;

    public string NamaMataKuliah { get; init; } = null!;

    public int Sks { get; init; } 

    public string RuangKuliah { get; init; } = null!;

    public string DosenPengampu { get; init; } = null!;

    public string UrlValue { get; init; } = null!;

    public DateOnly TanggalKuliah { get; init; } 

    public TimeOnly JamMulaiKuliah { get; init; } 

    public TimeOnly JamBerakhirKuliah { get; init; } 
}