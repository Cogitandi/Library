using Library.Core;
using Library.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Configuration
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey("Id");
            builder.Property("Name");
            builder.Property("Author");
            builder.Property("IsBorrowed");
            builder.HasMany(x => x.Actions).WithOne(y => y.Book);
        }
    }
}
