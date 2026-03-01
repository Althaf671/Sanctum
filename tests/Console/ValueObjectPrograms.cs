using src.Domain.Enums;
using src.Domain.ValueObjects;

namespace ValueObjectsPrograms;
internal class ValueObjectsTest
{
    //================== Isi Materi value object Test ==================//
    internal static void IsiMateriValueObjectTest()
    {
        Console.WriteLine("");
        Console.WriteLine("//==========================//");
        Console.WriteLine("// Program Input Isi Materi //");
        Console.WriteLine("//==========================//");
        Console.WriteLine("");  

        Console.Write("Input URL referensi: ");
        var url = Console.ReadLine();

        Console.Write("Input Ringkasan: ");
        var ringkasan = Console.ReadLine();

        var result = IsiMateri.Create(url!, ringkasan!);
        if (result.IsSuccess)
            Console.WriteLine("");
            Console.WriteLine("SUCCESS:");
            Console.WriteLine($"Original Path: {result.Value!.OriginalFileURL.Value}");
            Console.WriteLine($"Ringkasan: {result.Value!.Ringkasan}");

        if (result.IsFailure)
        {
            Console.WriteLine($"ERROR: {result.Error}");
            Console.WriteLine("");           
        }

        Console.WriteLine("");
        Console.WriteLine("//=========== END ==========//");
        Console.WriteLine("");
    }
    
    //================== Masa Kuliah value object Test ==================//
    internal static void MasaKuliahValueObjectTest()
    {
        Console.WriteLine("");
        Console.WriteLine("//===========================//");
        Console.WriteLine("// Program Input Masa Kuliah //");
        Console.WriteLine("//===========================//");
        Console.WriteLine("");
        
        var masaKuliah = MasaKuliah.Create(SemesterPeriod.GENAP, DateTime.UtcNow.Year);
        if (masaKuliah.IsSuccess)
        {
            Console.WriteLine("SUCCESS:");
            Console.WriteLine($"Tahun Ajaran: {masaKuliah.Value!.Start} - {masaKuliah.Value!.End}");
            Console.WriteLine($"Perkiraan Durasi: {masaKuliah.Value!.Durasi} ({masaKuliah.Value!.Durasi.TotalDays} Hari)");
        }

        if (masaKuliah.IsFailure)
        {
            Console.WriteLine($"ERROR: {masaKuliah.Error}");
            Console.WriteLine("");
        }

        Console.WriteLine("");
        Console.WriteLine("//=========== END ===========//");
        Console.WriteLine("");
    }

    //================== Url value object Test ==================//
    internal static void UrlValueObjectTest()
    {
        Console.WriteLine("");
        Console.WriteLine("//===================//");
        Console.WriteLine("// Program Input Url //");
        Console.WriteLine("//===================//");
        Console.WriteLine("");

        Console.WriteLine("");
        Console.WriteLine("//======= END =======//");
        Console.WriteLine("");
    }

    //================== Waktu Kuliah value object Test ==================//
    internal static void WaktuKuliahValueObjectTest()
    {
        Console.WriteLine("");
        Console.WriteLine("//============================//");
        Console.WriteLine("// Program Input Waktu Kuliah //");
        Console.WriteLine("//============================//");
        Console.WriteLine("");

        Console.WriteLine("");
        Console.WriteLine("//============ END ===========//");
        Console.WriteLine("");
    }
}