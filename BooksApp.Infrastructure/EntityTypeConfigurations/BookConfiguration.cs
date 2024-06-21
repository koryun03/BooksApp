using BooksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApp.Infrastructure.EntityTypeConfigurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id).IsUnique();

            builder.HasOne(p => p.Author)
                .WithMany(p => p.Books).HasForeignKey(m => m.AuthorId).OnDelete(DeleteBehavior.Cascade);

        }

    }
}
