using src.Domain.Common;
using src.Domain.Enums;
using src.Domain.ValueObjects;

namespace src.Domain.Entities;

public sealed class Jurusan : IAggregateRoot ,IEntity
{
    public Guid Id { get; private set; }

    public string KodeJurusan { get; private set; } = string.Empty;

    public string NamaJurusan { get; private set; } = string.Empty;

    public string NamaFakultas { get; private set; } = string.Empty;

    public Jenjang Jenjang { get; private set; }

    public Akreditasi Akreditasi { get; private set; }

    public MasaKuliah MasaKuliah { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; } 

    // EF core private constructor
    private Jurusan() { }

    // Factory
    public static Result<Jurusan> DaftarkanJurusan()
    {
        return Result<Jurusan>.Success(new Jurusan());
    }

    // Private constructor
    private Jurusan(string something)
    {
        
    }  

    // Validate invariant  
}