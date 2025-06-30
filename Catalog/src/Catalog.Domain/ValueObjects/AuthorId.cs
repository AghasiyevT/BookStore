namespace Catalog.Domain.ValueObjects
{
    public sealed class AuthorId
    {
        public Guid Guid { get; }

        private AuthorId(Guid guid)
        {
            Guid = guid;
        }

        public static AuthorId CreateNew() => new AuthorId(Guid.NewGuid());

        public override string ToString() => Guid.ToString();

    }
}
