namespace Catalog.Domain.ValueObjects;

public sealed class BookId
{
    public Guid Value { get; private set; }
    public BookId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("BookId cannot be empty.", nameof(value));
        Value = value;
    }
    public override string ToString() => Value.ToString();
}

