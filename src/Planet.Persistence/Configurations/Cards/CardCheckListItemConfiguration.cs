using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Cards;

namespace Planet.Persistence.Configurations.Cards
{
    internal class CardCheckListItemConfiguration : IEntityTypeConfiguration<CardCheckListItem>
    {
        public void Configure(EntityTypeBuilder<CardCheckListItem> builder)
        {
            builder.ToTable("CardCheckListItems");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.OwnsOne(c => c.Content, contentBuilder =>
            {
                contentBuilder.Property(cb => cb.Value)
                    .HasColumnName("Content")
                    .HasMaxLength(200)
                    .IsRequired();
            });
            builder.Navigation(c => c.Content).IsRequired();
        }
    }
}
