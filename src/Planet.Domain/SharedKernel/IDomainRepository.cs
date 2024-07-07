namespace Planet.Domain.SharedKernel
{
    public interface IDomainRepository<T> where T : Entity, IAggregateRoot
    {
        Task CreateAsync(T entity);
        Task<T> FindAsync(Guid id);

    }
}
