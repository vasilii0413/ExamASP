using Lab3_V3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Lab3_V3.Controllers
{
    public class ReadersController : Controller
    {
        private readonly ApplicationContext _ctx;

        public ReadersController(ApplicationContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        public IActionResult ShowReaders()
        {

            return View(_ctx.Readers.Include("book").ToList());
        }
        [HttpGet]
        public IActionResult AddReader()
        {
            ViewBag.BookId = new SelectList(_ctx.Books, "BookId", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult AddReader(ReaderModel reader)
        {
            _ctx.Readers.Add(reader);
            _ctx.SaveChanges();
            return RedirectToAction("ShowReaders");
        }

        [HttpGet]
        public IActionResult EditReader(int id)
        {
            ViewBag.BookId = new SelectList(_ctx.Books, "BookId", "Title");

            ReaderModel reader = _ctx.Readers.Find(id);
            return View(reader);
        }
        [HttpPost]
        public IActionResult EditReader(ReaderModel reader)
        {
            _ctx.Readers.Update(reader);
            _ctx.SaveChanges();
            return RedirectToAction("ShowReaders");
        }

        public IActionResult DeleteReader(int id)
        {
            ReaderModel reader = _ctx.Readers.Find(id);
            _ctx.Readers.Remove(reader);
            _ctx.SaveChanges();
            return RedirectToAction("ShowReaders");
        }
    }
}
