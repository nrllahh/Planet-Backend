using Microsoft.EntityFrameworkCore;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.SharedKernel;
using Planet.Domain.Users;
using Planet.Persistence.Configurations.Users;

namespace Planet.Persistence.Contexts
{
    public sealed class PlanetContext : DbContext, IUnitOfWork
    {

        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }
        public PlanetContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
