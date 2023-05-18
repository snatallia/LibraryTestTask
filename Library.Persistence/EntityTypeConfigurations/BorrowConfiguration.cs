﻿using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class BorrowConfiguration : IEntityTypeConfiguration<Borrow>
    {
        public void Configure(EntityTypeBuilder<Borrow> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasOne<Book>(br => br.Book)
                .WithMany(book => book.Borrows)
                .HasForeignKey(br => br.BookId);

        }
    }
}