using src.SharedKernel.Domain.Common;

namespace src.Modules.AcademicDomain.ValueObjects;

public sealed class Deadline : ValueObject
{
    public override IEnumerable<object> GetAtomicValue()
    {
        throw new NotImplementedException();
    }
}