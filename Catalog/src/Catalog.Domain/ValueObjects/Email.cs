namespace Catalog.Domain.ValueObjects;

public class Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Invalid email format");
        Value = value;
    }
    
}
