using System.Globalization;
using src.Modules.AcademicDomain.Enums;
using src.Modules.AcademicDomain.Errors.EntityErrors;
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;
using src.SharedKernel.Domain.Entities;
using src.SharedKernel.Domain.ValueObjects;

namespace src.Modules.AcademicDomain.Entities.MahasiswaAggregate;

public sealed partial class Mahasiswa : IAggregateRoot, IEntity
{
    public Guid Id { get; private set; }

    // Universitas
    public string NamaUniversitas { get; private set; } = string.Empty;

    public KodeUniversitas? KodeUniversitas { get; private set; } 

    public string SingkatanUniversitas { get; private set; } = string.Empty;

    public Url? LinkWebUniversitas { get; private set; } 

    // Fakultas
    public string NamaFakultas { get; private set; } = string.Empty;

    public KodeFakultas? KodeFakultas { get; private set; } 

    public string SingkatanFakultas { get; private set; } = string.Empty;

    public Url? LinkiLearn { get; private set; }

    // Jurusan
    public string KodeJurusan { get; private set; } = string.Empty;

    public string NamaJurusan { get; private set; } = string.Empty;

    public Jenjang Jenjang { get; private set; }

    public bool IsDeleted { get; private set; } 

    public DateTime? UpdatedAt { get; private set; }

    public DateTime CreatedAt { get; private set; }

    // Foreign key
    public Guid UserId { get; private set; } 

    // Constructors
    private Mahasiswa() { }

    private Mahasiswa(
        string namaUniversitas,
        string namaFakultas,
        string namaJurusan,
        string singkatanUniversitas,
        string singkatanFakultas,
        string kodeJurusan,
        KodeUniversitas? kodeUniversitas,
        KodeFakultas? kodeFakultas,
        Url? linkWebUniversitas,
        Url? linkiLearn,
        Jenjang jenjang,
        Guid userId)
    {
        Id = Guid.NewGuid();
        NamaUniversitas = namaUniversitas;
        NamaFakultas = namaFakultas;
        NamaJurusan = namaJurusan;

        SingkatanUniversitas = singkatanUniversitas;
        SingkatanFakultas = singkatanFakultas;

        KodeUniversitas = kodeUniversitas;
        KodeFakultas = kodeFakultas;
        KodeJurusan = kodeJurusan;

        LinkWebUniversitas = linkWebUniversitas;
        LinkiLearn = linkiLearn;
        
        IsDeleted = false;
        Jenjang = jenjang;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }

    // Factory
    public static Result<Mahasiswa> BuatProfileMahasiswa(
        string namaUniversitas,
        string namaFakultas,
        string namaJurusan,
        string singkatanUniversitas,
        string singkatanFakultas,
        string kodeJurusan,
        KodeUniversitas? kodeUniversitas,
        KodeFakultas? kodeFakultas,
        Url? linkWebUniversitas,
        Url? linkiLearn,
        Jenjang jenjang,
        Guid userId)
    {
        if (userId == Guid.Empty)
            return Result<Mahasiswa>.Failure(MahasiswaErrors.UserNotFound());

        var reqUniFields = ValidateUniversitasRequiredFields(namaUniversitas, singkatanUniversitas);
        if (reqUniFields.IsFailure)
            return Result<Mahasiswa>.Failure(reqUniFields.Error);

        var reqFakFields = ValidateFakultasRequiredFields(namaFakultas, singkatanFakultas);
        if (reqFakFields.IsFailure)
            return Result<Mahasiswa>.Failure(reqFakFields.Error);

        var reqJurFields = ValidateJurusanRequiredFields(namaJurusan, kodeJurusan);
        if (reqJurFields.IsFailure)
            return Result<Mahasiswa>.Failure(reqJurFields.Error);

        var normalizeNamaUni = NormalizeNama(namaUniversitas);

        var normalizeNamaFak = NormalizeNama(namaFakultas);

        var normalizeSingkUni = NormalizeSingkatan(singkatanUniversitas);

        var normalizeSingFak = NormalizeSingkatan(singkatanFakultas);

        var uniValidation = ValidateUniversitasInvariant(
            normalizeNamaUni, 
            normalizeSingkUni);
        if (uniValidation.IsFailure)
            return Result<Mahasiswa>.Failure(uniValidation.Error);

        var fakValidation = ValidateFakultasInvariant(
            normalizeNamaFak, 
            normalizeSingFak);
        if (fakValidation.IsFailure)
            return Result<Mahasiswa>.Failure(fakValidation.Error);

        var jurValidation = ValidateJurusanInvariant(namaJurusan, kodeJurusan);
        if (jurValidation.IsFailure)
            return Result<Mahasiswa>.Failure(jurValidation.Error);

        return Result<Mahasiswa>.Success(new Mahasiswa(
            normalizeNamaUni,
            normalizeNamaFak,
            namaJurusan,
            normalizeSingkUni,
            normalizeSingFak,
            kodeJurusan,
            kodeUniversitas,
            kodeFakultas,
            linkWebUniversitas,
            linkiLearn,
            jenjang,
            userId
        ));
    }

    private static string NormalizeNama(string nama) =>
      CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nama.Trim().ToLowerInvariant());

    private static string NormalizeSingkatan(string singkatan) =>
        singkatan.Replace(" ", "").ToUpperInvariant();
}