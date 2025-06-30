namespace Catalog.Domain.ValueObjects;

public class FullName
{
    public string First { get; }
    public string Last { get; }

    public FullName(string first, string last)
    {
        if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last))
            throw new ArgumentException("Name fields cannot be empty");
        First = first;
        Last = last;
    }

    public override string ToString() => $"{First} {Last}";

}
