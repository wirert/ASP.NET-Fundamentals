using ForumApp.Data;
using ForumApp.Data.Entities;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext context;

        public PostController(ForumAppDbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var models = await context.Posts
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();

            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddPostViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await context.Posts
                .AddAsync(new Post()
                {
                    Title = model.Title,
                    Content = model.Content
                });

            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await context.Posts
                .Where(p => p.IsDeleted == false && p.Id == id)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = new PostViewModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = await context.Posts.FindAsync(model.Id);

            if (entity != null)
            {
                entity.Title = model.Title;
                entity.Content = model.Content;

                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await context.Posts.FindAsync(id);

            if (entity != null)
            {
               entity.IsDeleted = true;
               await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
