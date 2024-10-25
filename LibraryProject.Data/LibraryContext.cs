using LibraryProject.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryProject.Data;

public class LibraryContext : IdentityDbContext<ApplicationUser>
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<BorrowBook> BorrowBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Library>()
            .HasMany(l => l.Books)
            .WithOne(b => b.Library)
            .HasForeignKey(b => b.LibraryId);


        modelBuilder.Entity<Book>()
            .HasMany(b => b.BorrowBooks)
            .WithOne(bb => bb.Book)
            .HasForeignKey(bb => bb.BookId);

        modelBuilder.Entity<Book>()
            .Property(b => b.AmountPages)
            .IsRequired()
            .HasColumnType("integer");
    }

}
