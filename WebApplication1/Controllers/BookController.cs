using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        private readonly Context _context;
        private readonly IBookRepository _bookRepository;
        public BookController(Context context, IBookRepository bookRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _bookRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreeateVm book)
        {
            if (ModelState.IsValid)
            {
                var result = _bookRepository.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return NotFound();

            var book = await _bookRepository.FindById(id);
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookEditVm book)
        {
            if (id != book.BookId) return NotFound();

            if (ModelState.IsValid)
            {
                await _bookRepository.Edit(book);
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound();

            var book = await _bookRepository.FindById(id);
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _bookRepository.FindById(id);
            if (book != null)
            {
                await _bookRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

