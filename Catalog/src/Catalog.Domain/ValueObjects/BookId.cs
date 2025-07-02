namespace Catalog.Domain.ValueObjects;

public sealed class BookId
{
    public Guid Guid { get; }

    private BookId(Guid guid)
    {
        Guid = guid;
    }

    public static BookId CreateNew() => new BookId(Guid.NewGuid());

    public override string ToString() => Guid.ToString();



}

