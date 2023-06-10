using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Models.Home;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext context;

        public HomeController(TaskBoardAppDbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var taskBoards = context.Boards
                .AsNoTracking()
                .Select(b => b.Name)
                .Distinct();

            var tasksCount = new List<HomeBoardModel>();

            foreach (var taskBoard in taskBoards)
            {
                tasksCount.Add(new HomeBoardModel()
                {
                    BoardName = taskBoard,
                    TaskCount = context.Tasks
                                .AsNoTracking()
                                .Where(t => t.Board!.Name == taskBoard)
                                .Count()
                });
            }

            int userTasksCount = -1;

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                var userId = User!.FindFirst(ClaimTypes.NameIdentifier)!.Value;

                userTasksCount = context.Tasks
                                    .AsNoTracking()
                                    .Where(t => t.OwnerId == userId)
                                    .Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = context.Tasks.Count(),
                BoardsWithTasksCount = tasksCount,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}