using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Cards;
using Planet.Domain.Users;

namespace Planet.Persistence.Configurations.Cards
{
    internal class CardCommentConfiguration : IEntityTypeConfiguration<CardComment>
    {
        public void Configure(EntityTypeBuilder<CardComment> builder)
        {
            builder.ToTable("CardComments");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.OwnsOne(c => c.Content, contentBuilder =>
            {
                contentBuilder.Property(co => co.Value)
                    .HasColumnName("Content")
                    .HasMaxLength(200)
                    .IsRequired();
            });
            builder.Navigation(c => c.Content).IsRequired();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Card>()
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.CardId)
                .IsRequired();
        }
    }
}
