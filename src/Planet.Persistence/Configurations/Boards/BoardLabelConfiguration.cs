using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Boards;

namespace Planet.Persistence.Configurations.Boards
{
    internal class BoardLabelConfiguration : IEntityTypeConfiguration<BoardLabel>
    {
        public void Configure(EntityTypeBuilder<BoardLabel> builder)
        {
            builder.ToTable("BoardLabels");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.OwnsOne(b => b.Title, titleBuilder =>
            {
                titleBuilder.Property(c => c.Value)
                    .HasColumnName("Title")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            builder.Navigation(b => b.Title).IsRequired();

            builder.OwnsOne(b => b.Color, colorBuilder =>
            {
                colorBuilder.Property(c => c.Value)
                    .HasColumnName("ColorCode")
                    .HasMaxLength(7)
                    .HasDefaultValue("#ffffff")
                    .IsRequired();
            });
            builder.Navigation(b => b.Color).IsRequired();
        }
    }
}
