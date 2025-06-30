namespace Catalog.Domain.Exceptions;

public class InvalidISBNException(string message) : Exception(message)
{
}
