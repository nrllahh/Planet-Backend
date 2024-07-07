using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Boards;

namespace Planet.Persistence.Configurations.Boards
{
    internal class BoardListConfiguration : IEntityTypeConfiguration<BoardList>
    {
        public void Configure(EntityTypeBuilder<BoardList> builder)
        {
            builder.ToTable("BoardLists");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.OwnsOne(l => l.Title, titleBuilder =>
            {
                titleBuilder.Property(t => t.Value)
                .HasColumnName("Title")
                .HasMaxLength(50)
                .IsRequired();
            });
            builder.Navigation(l => l.Title).IsRequired();

        }
    }
}
