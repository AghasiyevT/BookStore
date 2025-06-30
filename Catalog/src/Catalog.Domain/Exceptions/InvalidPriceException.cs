namespace Catalog.Domain.Exceptions;

public class InvalidPriceException(string message) : Exception(message)
{
}
