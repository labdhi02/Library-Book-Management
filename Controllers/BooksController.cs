using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // List all books (Index)
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        // Show book details (Read)
        public IActionResult Details(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                TempData["Error"] = "Book not found!";
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // Show form to add a new book (Create - GET)
        public IActionResult Create()
        {
            ViewBag.Title = "Add New Book";
            ViewBag.Action = "Create";
            return View(new Book());
        }

        // Handle adding a new book (Create - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                TempData["Message"] = "Book added successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Title = "Add New Book";
            ViewBag.Action = "Create";
            return View(book);
        }

        // Show form to edit an existing book (Update - GET)
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                TempData["Error"] = "Book not found!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Title = "Edit Book";
            ViewBag.Action = "Edit";
            return View("Create", book); // Reuse Create view
        }

        // Handle editing a book (Update - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                TempData["Message"] = "Book updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Title = "Edit Book";
            ViewBag.Action = "Edit";
            return View("Create", book); // Reuse Create view
        }

        // Show confirmation to delete a book (Delete - GET)
        // Show confirmation to delete a book (Delete - GET)
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                TempData["Error"] = "Book not found!";
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // Handle deleting a book (Delete - POST)
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                TempData["Message"] = "Book deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Book not found!";
            }

            // Redirecting to the specified URL
            return RedirectToAction(nameof(Index));

        }


    }
}
