using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.Common;

namespace src.Modules.AcademicDomain.Errors.ValueObjectErrors;
public static class WaktuKuliahErrors
{
    public static Error InvalidRentangWaktu()
    {
        return new Error(
            "WaktuKuliahErrors.InvalidRentangWaktu",
            "Waktu mulai tidak boleh lebih besar dari waktu berakhir!",
            nameof(WaktuKuliah)
        );
    }

    public static Error ExceedBatasMaksDurasi()
    {
        return new Error(
            "WaktuKuliahErrors.ExceedBatasMaksDurasi",
            "Durasi kuliah tidak boleh lebih dari 4 jam!",
            nameof(WaktuKuliah)
        );  
    }
}