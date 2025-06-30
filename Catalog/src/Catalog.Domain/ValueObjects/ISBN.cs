namespace Catalog.Domain.ValueObjects;

public sealed class ISBN
{
    public string Value { get; }

    public ISBN(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 10)
            throw new ArgumentException("Invalid ISBN format.");
        Value = value;
    }

}


