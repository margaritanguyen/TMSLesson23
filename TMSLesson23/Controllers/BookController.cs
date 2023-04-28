using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TMSLesson23.Models;

namespace TMSLesson23.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private ApplicationContext db;

        public BookController(ILogger<BookController> logger, ApplicationContext context)
        {
            _logger = logger;
            this.db = context;
        }

        public async Task<IActionResult> Index()
        {
            var books = await db.Books.ToListAsync();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book model)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}