using Library.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Data.Configuration
{
    class BookActionConfiguration : IEntityTypeConfiguration<BookAction>
    {
        public void Configure(EntityTypeBuilder<BookAction> builder)
        {
            builder.HasKey("Id");
            builder.HasOne(x => x.Book).WithMany(y => y.Actions);
            builder.HasOne(x => x.User);
            builder.Property("Date");
            builder.Property("Name");
        }
    }
}
