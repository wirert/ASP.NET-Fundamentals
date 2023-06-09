using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext context;

        public TaskController(TaskBoardAppDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var model = new TaskFormModel()
            {
                Boards = await GetBoards()
            };

            return View(model);
        }

        private Task<List<TaskBoardModel>> GetBoards()
        {
            return context.Boards
                      .AsNoTracking()
                      .Select(b => new TaskBoardModel()
                      {
                          Id = b.Id,
                          Name = b.Name
                      })
                      .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!(await GetBoards()).Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
            }

            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                model.Boards = await GetBoards();

                return View(model);
            }

            var task = new Task()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                BoardId = model.BoardId,
                OwnerId = currentUserId
            };

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await context.Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board!.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await context.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var model = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = await GetBoards()
            };

            return View(model);
        }
    }
}
