using src.Domain.Entities;
using src.Domain.ValueObjects;

namespace EntitiesProgram;
internal sealed class EntitiesTest
{
    //================== Mata Kuliah Entity Test ==================//
    internal static void MataKuliahEntityTest()
    {
        Console.WriteLine("");
        Console.WriteLine("//============================//");
        Console.WriteLine("// Program Tambah Mata Kuliah //");
        Console.WriteLine("//============================//");  
        Console.WriteLine("");

        Console.Write("Input kode mata kuliah: ");
        var kodeMataKuliah = Console.ReadLine();

        Console.Write("Input nama mata kuliah: ");
        var namaMataKuliah = Console.ReadLine();

        Console.Write("Input jumlah sks: ");
        var jumlahSks = int.Parse(Console.ReadLine()!);

        Console.Write("Input tanggal kuliah: ");
        DateOnly tanggalKuliah = DateOnly.Parse(Console.ReadLine()!);

        Console.Write("Input jam mulai kuliah: ");
        var jamMulaiKuliah = TimeOnly.Parse(Console.ReadLine()!);

        Console.Write("Input jam berakhir kuliah: ");
        var jamBerakhirKuliah = TimeOnly.Parse(Console.ReadLine()!);

        Console.Write("Input ruang kuliah: ");
        var ruangKuliah = Console.ReadLine();

        Console.Write("Input dosen pengampu: ");
        var dosenPengampu = Console.ReadLine();

        Console.Write("Input link folder: ");
        var linkFolder = Console.ReadLine();

        var waktuKuliahRes = WaktuKuliah.Create(tanggalKuliah, jamMulaiKuliah, jamBerakhirKuliah).Value!;
        var linkFolderRes = Url.Create(linkFolder!).Value!;

        var revisiInfoMataKuliah = new RevisiInfoMataKuliahDto(
            kodeMataKuliah!, namaMataKuliah!, jumlahSks,
            ruangKuliah!, dosenPengampu!,linkFolderRes);

        // Buat mata kuliah baru
        var mataKuliah = MataKuliah.TambahMataKuliah(new TambahMataKuliahDto(
            revisiInfoMataKuliah, waktuKuliahRes
        ));

        if (mataKuliah.IsSuccess)
        {
            Console.WriteLine("");
            Console.WriteLine("SUCCESS:");
            Console.WriteLine($"Kode Mata Kuliah: {mataKuliah.Value!.KodeMataKuliah}");
            Console.WriteLine($"Nama Mata Kuliah: {mataKuliah.Value!.NamaMataKuliah}");
            Console.WriteLine($"Total SKS: {mataKuliah.Value!.Sks}");
            Console.WriteLine($"Jadwal Kuliah: {mataKuliah.Value!.WaktuKuliah.JamMulai} - {mataKuliah.Value.WaktuKuliah.JamBerakhir}");
            Console.WriteLine($"Durasi Perkuliah: {mataKuliah.Value!.WaktuKuliah.Durasi} ({mataKuliah.Value.WaktuKuliah.Durasi.TotalHours} Jam)");
            Console.WriteLine($"Ruang Kuliah: {mataKuliah.Value!.RuangKuliah}");
            Console.WriteLine($"Dosen Pengampu: {mataKuliah.Value!.DosenPengampu}");
            Console.WriteLine($"Link Folder: {mataKuliah.Value!.LinkFolder.Value}");
            Console.WriteLine("");      
        }

        if (mataKuliah.IsFailure)
        {
            Console.WriteLine("");
            Console.WriteLine($"ERROR: {mataKuliah.Error}");
            Console.WriteLine("");       
        }

        Console.WriteLine("");
        Console.WriteLine("//============= END ==============//"); 
        Console.WriteLine("");
    }
    //==============================================================//

    //================== Jurusan Entity Test ==================//
    internal static void JurusanEntityTest()
    {
        Console.WriteLine("//============= END ==============//"); 
    }
    //==============================================================//

    //================== Materi Entity Test ==================//
    internal static void MateriEntityTest()
    {
        Console.WriteLine("//============= END ==============//"); 
    }
    //==============================================================//

    //================== Tugas Entity Test ==================//
    internal static void TugasEntiyTest()
    {
        Console.WriteLine("//============= END ==============//"); 
    }
    //==============================================================//

}