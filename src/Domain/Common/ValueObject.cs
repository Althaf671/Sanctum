namespace src.Domain.Common;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        var flag = a.Equals(b);

        return flag;
    }

    public static bool operator !=(ValueObject? a, ValueObject? b) =>
        !(a == b);
    

    public bool Equals(ValueObject? other) =>
        other is not null && ValuesAreEqual(other);
    

    public override bool Equals(object? obj) =>
        obj is ValueObject valueObject && ValuesAreEqual(valueObject); 

    public abstract IEnumerable<object> GetAtomicValue();

    private bool ValuesAreEqual(ValueObject valueObject) =>
        GetAtomicValue()
            .SequenceEqual(valueObject.GetAtomicValue());

    public override int GetHashCode() =>
        GetAtomicValue().Aggregate(
            default(int),
            (hashcode, value) =>
                HashCode.Combine(hashcode, value.GetHashCode())
        );
}