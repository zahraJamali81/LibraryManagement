using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Context _context;
        public BookRepository (Context context)
        {  _context = context; }

        public async Task<bool> Add(BookCreeateVm bookCreeateVm)
        {
            BookModel book = new BookModel();
            book.Author = bookCreeateVm.Author;
            book.Title = bookCreeateVm.Title;
            book.Subject = bookCreeateVm.Subject;
            book.Status = bookCreeateVm.Status;
            book.CopiesAvailable = bookCreeateVm.CopiesAvailable;

            _context.Books.Add(book);
            _context.SaveChangesAsync();

            return true;

        }
        public async Task<bool> Delete(int bookId)
        {
            var Book = await _context.Books.Where(w => w.BookId == bookId).ExecuteDeleteAsync();

            return Book > 0;

        }

        public async Task<bool> Edit(BookEditVm bookEditVm)
        {
            var book = await _context.Books.SingleOrDefaultAsync(b => b.BookId == bookEditVm.BookId);
            if (book == null)
            {
                return false;
            }

            book.BookId = bookEditVm.BookId;
            book.Author = bookEditVm.Author;
            book.Title = bookEditVm.Title;
            book.Subject = bookEditVm.Subject;
            book.Status = bookEditVm.Status;
            book.CopiesAvailable = bookEditVm.CopiesAvailable;
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BookVm?> FindById(int bookId)
        {
            return await _context.Books.AsNoTracking()
                .Where(w=> w.BookId == bookId)
                .Select(s => new BookVm
                {
                    Title = s.Title,
                    Subject = s.Subject,
                    Author = s.Author,
                    Status = s.Status,
                    CopiesAvailable = s.CopiesAvailable
                })
                .SingleOrDefaultAsync();
        }

        public async Task<List<BookVm>> GetAll()
        {
            return await _context.Books.AsNoTracking()
                .Select(s => new BookVm
                {
                    Title = s.Title,
                    Subject = s.Subject,
                    Author = s.Author,
                    Status = s.Status
                }).ToListAsync();
        }
    }
}
