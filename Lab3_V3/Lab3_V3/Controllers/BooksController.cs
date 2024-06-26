using Lab3_V3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_V3.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationContext _ctx;

        public BooksController(ApplicationContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        public IActionResult ShowBooks()
        {
            return View(_ctx.Books.ToList());
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookModel book)
        {
            _ctx.Books.Add(book);
            _ctx.SaveChanges();
            return View("ShowBooks", _ctx.Books.ToList());
        }
        [HttpGet]
        public IActionResult EditBook(int id)
        {
            BookModel book= _ctx.Books.Find(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult EditBook(BookModel book)
        {
            _ctx.Books.Update(book);
            _ctx.SaveChanges();
            return RedirectToAction("ShowBooks");
        }

        public IActionResult DeleteBook(int id)
        {
            BookModel book = _ctx.Books.Find(id);
            _ctx.Books.Remove(book);
            _ctx.SaveChanges();
            return RedirectToAction("ShowBooks");
        }
    }
}
