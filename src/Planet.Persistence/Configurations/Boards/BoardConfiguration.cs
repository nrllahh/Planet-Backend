using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Boards;
using Planet.Domain.Users;

namespace Planet.Persistence.Configurations.Boards
{
    internal class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.OwnsOne(b => b.Title, titleBuilder =>
            {
                titleBuilder.Property(t => t.Value)
                    .HasColumnName("Title")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            builder.Navigation(b => b.Title).IsRequired();

            builder.OwnsOne(b => b.Description, descriptionBuilder =>
            {
                descriptionBuilder.Property(d => d.Value)
                    .HasColumnName("Description")
                    .HasMaxLength(200)
                    .IsRequired();
            });
            builder.Navigation(b => b.Description).IsRequired();

            builder.OwnsMany(b => b.Members, boardBuilder =>
            {
                boardBuilder.ToTable("BoardMembers");
                boardBuilder.WithOwner().HasForeignKey(m => m.BoardId);
                boardBuilder.HasOne<User>().WithMany().HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.NoAction);
                boardBuilder.HasKey(m => new { m.BoardId, m.UserId });
            });

            // OwnerId configuration
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(b => b.OwnerId)
                .IsRequired();

            // BoardList configuration
            builder.HasMany(b => b.Lists)
                .WithOne()
                .HasForeignKey(b => b.BoardId)
                .IsRequired();

            // BoardLabel configuration
            builder.HasMany(b => b.Labels)
                .WithOne()
                .HasForeignKey(b => b.BoardId);
        }
    }
}
