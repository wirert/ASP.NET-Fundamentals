using Library.Contracts;
using Library.Models.Book;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService _bookService)
        {
            bookService = _bookService;
        }

        public async Task<IActionResult> All()
        {
            var books = await bookService.GetAllAsync();

            return View(books);
        }

        public async Task<IActionResult> Mine()
        {
            var userId = GetUserId();

            if (userId == null)
            {
                return BadRequest();
            }

            var books = await bookService.GetMineAsync(userId);

            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await bookService.FindBookByIdAsync(id);

            if (book != null)
            {
                var userId = GetUserId();

                await bookService.AddBookToCollection(userId, book);
            }   

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await bookService.FindBookByIdAsync(id);

            if (book != null)
            {
                var userId = GetUserId();

                await bookService.RemoveBookToCollection(userId, book);
            }

            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await bookService.GetCategoriesAsync();

            var model = new AddBookViewModel()
            {
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await bookService.GetCategoriesAsync();

                return View(model);
            }

            await bookService.AddNewBookAsync(model);

            return RedirectToAction(nameof(All));
        }

    }
}
