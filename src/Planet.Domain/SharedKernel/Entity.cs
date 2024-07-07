namespace Planet.Domain.SharedKernel
{
    public abstract class Entity : IEquatable<Entity>
    {
        #region Properties
        public Guid Id { get; private set; }
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents?.ToList();
        #endregion

        #region Private fields
        private readonly IList<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        #endregion

        #region Constructors
        protected Entity(Guid id)
        {
            Id = id;
        }
        #endregion

        public void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is not Entity entity)
            {
                return false;
            }

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Entity other)
        {
            if (other is null)
            {
                return false;
            }

            return other.Id == Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null || b is null)
            {
                return false;
            }

            return a.Id == b.Id;
        }

        public static bool operator !=(Entity a, Entity b)
        {
            if (a is null || b is null)
            {
                return true;
            }

            return a.Id != b.Id;
        }

    }
}
