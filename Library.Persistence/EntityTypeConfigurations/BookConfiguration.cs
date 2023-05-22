using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.IBAN).IsUnique();
            builder.Property(b => b.IBAN).HasMaxLength(17);//xxx-x-xxxxxx-xx-x
            builder.Property(b => b.Title).IsRequired().HasMaxLength(250);
            builder.HasMany<Borrow>(b => b.Borrows)
               .WithOne(br => br.Book)
               .HasForeignKey(br => br.BookId)         
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
