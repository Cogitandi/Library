using Library.Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Library.Core.Domain;

namespace Library.Infrastructure.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAction> BookActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookActionConfiguration());

            // Sample data seeded to the database
            modelBuilder.Entity<Book>().HasData(
                new Book() {Id=Guid.NewGuid(),Author="Jan Kowalski",IsBorrowed=false,Name="Opowieść o czarnym groszku"},
                new Book() { Id = Guid.NewGuid(), Author = "Nosowska Katarzyna",IsBorrowed=false,Name= "Powrót z Bambuko" },
                new Book() { Id = Guid.NewGuid(), Author ="Kamil Zbójnik",IsBorrowed=false,Name="Poradnik pianisty"},
                new Book() { Id = Guid.NewGuid(), Author = "Lackberg Camilla", IsBorrowed=false,Name= "Srebrne skrzydła" },
                new Book() { Id = Guid.NewGuid(), Author = "Lackberg Camilla", IsBorrowed=false,Name= "Złota klatka" },
                new Book() { Id = Guid.NewGuid(), Author = "Ernset Tkaczyk",IsBorrowed=false,Name="Książka kucharska"}
                );
            modelBuilder.Entity<IdentityUser<Guid>>().HasData(new IdentityUser<Guid>{
                Id=Guid.NewGuid(),
                Email = "a@b.pl", 
                NormalizedEmail = "A@B.PL",
                UserName = "a@b.pl", 
                NormalizedUserName = "A@B.PL",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = "AQAAAAEAACcQAAAAEO8/uSW8LNw0nEf+FbjTMeLf4cxlHhO1GTDM4zsLikCe2DeU6kjfUJKhsAV/v5atzw==" 
            });
        }
    }
}
