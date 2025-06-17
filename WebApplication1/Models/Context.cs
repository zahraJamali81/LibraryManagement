using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> db) : base(db) { }

            public DbSet<PersonModel> Persons { get; set; }
            public DbSet<BookModel> Books { get; set; }
            public DbSet<BorrowModel> Borrows { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<BorrowModel>()
                    .HasKey(b => new { b.PersonId, b.BookId });

                modelBuilder.Entity<BorrowModel>()
                    .HasOne(b => b.Person)
                    .WithMany(p => p.Borrows)
                    .HasForeignKey(b => b.PersonId);

                modelBuilder.Entity<BorrowModel>()
                    .HasOne(b => b.Book)
                    .WithMany(bk => bk.Borrows)
                    .HasForeignKey(b => b.BookId);
            }
        }
    }


