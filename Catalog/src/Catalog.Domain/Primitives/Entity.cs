namespace Catalog.Domain.Primitives;

public abstract class Entity
{
    private List<DomainEvent> _domainEvents;
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents ??= new List<DomainEvent>();
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents?.Clear();
}
