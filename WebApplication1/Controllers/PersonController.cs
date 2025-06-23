using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        private readonly Context _context;
        private readonly IPersonRepository _personRepository;
        public PersonController(Context context, IPersonRepository personRepository)
        {
            _context = context;
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Persons.ToListAsync());
            return View(await _personRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonModel person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(person);
                    await _context.SaveChangesAsync();
                    //var result = await _personRepository.Add(person)
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = " Error saving: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Error = "The form is invalid.";
            }

            return View(person);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var person = await _context.Persons.FindAsync(id);
            if (person == null) return NotFound();

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PersonModel person)
        {
            if (id != person.PersonId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var person = await _context.Persons.FindAsync(id);
            if (person == null) return NotFound();

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}


