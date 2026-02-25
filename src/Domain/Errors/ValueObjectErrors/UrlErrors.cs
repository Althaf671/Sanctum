using src.Domain.Common;
using src.Domain.ValueObjects;

namespace src.Domain.Errors.ValueObjectErrors;
public static class UrlErrors
{
    private static readonly string _domain = nameof(Url);

    public static Error ValueRequired()
    {
        return new Error(
            "UrlErrors.ValueRequired", "Url value tidak boleh kosong!",
            _domain
        );
    }

    public static Error InvalidFormat()
    {
        return new Error(
            "UrlErrors.InvalidFormat", "Url tidak sesuai standar Uri sistem!",
            _domain
        );   
    }

    public static Error OnlyHttpsAllowed()
    {
        return new Error(
            "UrlErrors.OnlyHttpsAllowed", "Url harus https!",
            _domain
        );    
    }

    public static Error UriHostRequired()
    {
        return new Error(
            "UrlErrors.UriHostRequired", "Url host tidak boleh kosong!",
            _domain
        );      
    }

    public static Error InvalidLength()
    {
        return new Error(
            "UrlErrors.InvalidLength", "Url min atau max karater adalah 8 atau 2048!",
            _domain
        );     
    }
}