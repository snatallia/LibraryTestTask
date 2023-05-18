using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.IBAN).IsUnique();
            builder.Property(b => b.IBAN).IsRequired().HasMaxLength(17);//xxx-x-xxxxxx-xx-x
            builder.Property(b => b.Title).IsRequired().HasMaxLength(250);
            builder.HasOne<Author>(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
