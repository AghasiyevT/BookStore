namespace Catalog.Domain.Exceptions;

public class InvalidEmailException(string message) : Exception(message)
{
}
