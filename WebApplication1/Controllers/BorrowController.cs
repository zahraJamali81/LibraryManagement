using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class BorrowController : Controller
    {
        private readonly Context _context;

        public BorrowController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Persons = _context.Persons
                .AsNoTracking()
                .Select(s=> new PersonVm
                {
                    PersonId = s.PersonId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    phoneNumber = s.phoneNumber,
                }).ToList();
            ViewBag.Books = _context.Books.Where(b => b.CopiesAvailable > 0).ToList();
            return View(new BorrowModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(BorrowModel borrow)
        {
            ViewBag.Persons = _context.Persons.ToList();
            ViewBag.Books = _context.Books.Where(b => b.CopiesAvailable > 0).ToList();

            if (!ModelState.IsValid)
            {
                ViewBag.Error = "لطفاً تمام فیلدها را به درستی پر کنید.";
                return View(borrow);
            }

            var book = await _context.Books.FindAsync(borrow.BookId);
            if (book == null || book.CopiesAvailable <= 0)
            {
                ViewBag.Error = "کتاب مورد نظر موجود نیست.";
                return View(borrow);
            }

            var person = await _context.Persons.FindAsync(borrow.PersonId);
            if (person == null)
            {
                ViewBag.Error = "شخص انتخاب‌شده یافت نشد.";
                return View(borrow);
            }

            book.CopiesAvailable--;

            borrow.BorrowDate = DateTime.Now;
            borrow.ReternDate = DateTime.Now.AddDays(7);

            _context.Borrows.Add(borrow);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Book");
        }
    }
}
