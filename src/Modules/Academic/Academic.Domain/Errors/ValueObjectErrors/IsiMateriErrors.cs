using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;

namespace src.Modules.AcademicDomain.Errors.ValueObjectErrors;
public static class IsiMateriErrors
{
    private static readonly string _domain = nameof(IsiMateri);

    public static Error RingkasanRequired()
    {
        return new Error(
            "IsiMateriErrors.RingkasanRequired", "Nilai ringkasan tidak boleh kosong!",
            _domain
        );
    }

    public static Error InvalidRingkasanCharacterLength()
    {
        return new Error(
            "IsiMateriErrors.InvalidRingkasanCharacterLength", 
            "Nilai ringkasan tidak boleh lebih dari 1000 atau dibawah 10 karakter!",
            _domain
        );     
    }
}