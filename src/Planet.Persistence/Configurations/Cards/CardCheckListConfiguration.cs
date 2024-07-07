using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Cards;

namespace Planet.Persistence.Configurations.Cards
{
    internal class CardCheckListConfiguration : IEntityTypeConfiguration<CardCheckList>
    {
        public void Configure(EntityTypeBuilder<CardCheckList> builder)
        {
            builder.ToTable("CardCheckLists");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.OwnsOne(c => c.CardTitle, titleBuilder =>
            {
                titleBuilder.Property(ct => ct.Value)
                    .HasColumnName("Title")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            builder.Navigation(c => c.CardTitle).IsRequired();

            builder.HasMany(c => c.Items)
                .WithOne()
                .HasForeignKey(c => c.CheckListId)
                .IsRequired();
        }
    }
}
