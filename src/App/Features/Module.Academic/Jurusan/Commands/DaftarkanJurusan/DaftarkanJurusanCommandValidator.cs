using FluentValidation;

namespace src.App.Features.ModuleKuliah.Jurusan.Commands.DaftarkanJurusan;

public class DaftarkanJurusanValidator : AbstractValidator<DaftarkanJurusanCommand>
{
    public DaftarkanJurusanValidator()
    {
        RuleFor(x => x.KodeJurusan)
            .NotEmpty().WithMessage("Kode Jurusan tidak boleh kosong!")
            .MinimumLength(10).WithMessage("Minimal karakter Kode Jurusan adalah 10 karakter!")
            .MaximumLength(30).WithMessage("Maksimal karakter Kode Jurusan adalah 30 karakter!");

        RuleFor(x => x.NamaJurusan)
            .NotEmpty().WithMessage("Nama Jurusan tidak boleh kosong!")
            .MinimumLength(10).WithMessage("Minimal karakter Nama Jurusan adalah 10 karakter!")
            .MaximumLength(30).WithMessage("Maksimal karakter Nama Jurusan adalah 30 karakter!");

        RuleFor(x => x.NamaFakultas)
            .NotEmpty().WithMessage("Nama Fakultas tidak boleh kosong!")
            .MinimumLength(10).WithMessage("Minimal karakter Nama Fakultas adalah 10 karakter!")
            .MaximumLength(30).WithMessage("Maksimal karakter Nama Fakultas adalah 30 karakter!");

        RuleFor(x => x.Jenjang)
            .IsInEnum().WithMessage("Pilih salah satu Jenjang!");

        RuleFor(x => x.Akreditasi)
            .IsInEnum().WithMessage("Pilih salah satu Akreditasi!");
    }
}