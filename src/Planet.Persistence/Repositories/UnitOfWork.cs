using Planet.Domain.SharedKernel;
using Planet.Persistence.Contexts;

namespace Planet.Persistence.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly PlanetContext _context;

        public UnitOfWork(PlanetContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
