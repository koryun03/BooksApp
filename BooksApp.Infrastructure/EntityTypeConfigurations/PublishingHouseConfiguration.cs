using BooksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApp.Infrastructure.EntityTypeConfigurations
{
    internal class PublishingHouseConfiguration : IEntityTypeConfiguration<PublishingHouse>
    {
        public void Configure(EntityTypeBuilder<PublishingHouse> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id).IsUnique();

            builder.HasOne(p => p.Book)
                .WithMany(p => p.PublishingHouses).HasForeignKey(m => m.BookId).OnDelete(DeleteBehavior.Cascade);

        }

    }
}
