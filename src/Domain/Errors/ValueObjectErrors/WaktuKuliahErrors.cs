using src.Domain.Common;
using src.Domain.ValueObjects;

namespace src.Domain.Errors.ValueObjectErrors;
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