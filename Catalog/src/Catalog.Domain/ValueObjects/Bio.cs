namespace Catalog.Domain.ValueObjects;

public class Bio
{
    public string Text { get; }
    public Bio(string text)
    {
        Text = text.Length <= 1000 ? text : throw new ArgumentException("Bio too long");
    }
}
