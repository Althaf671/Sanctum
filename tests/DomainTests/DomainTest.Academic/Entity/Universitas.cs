using src.Modules.AcademicDomain.Entities.UniversitasAggregate;
using src.Modules.AcademicDomain.ValueObjects;
using src.SharedKernel.Domain.ValueObjects;

namespace DomainTest.Academic;

public class UniversitasTest
{
    // Happy path
    [Theory]
    [InlineData("uniVersitas AndaLAS", "unand", "DIF11", "https://unand.ac.id",
                "Universitas Andalas", "UNAND", "DIF11", "https://unand.ac.id")]
    public void Entity_ShouldCreated_IfInvariantMeet(
        string nama, string singkatan, string kode, string link,
        string expectedNama, string expectedSingkatan, string expectedKode, string expectedLink)
    {
        var univ = Universitas.DaftarkanUniversitas(nama, singkatan, kode, link);

        Assert.Equal(expectedNama, univ.Value!.Nama);
        Assert.Equal(expectedSingkatan, univ.Value!.Singkatan);
        Assert.Equal(expectedKode, univ.Value!.KodeUniversitas);
        Assert.Equal(expectedLink, univ.Value!.LinkWebsite);
    }
}
