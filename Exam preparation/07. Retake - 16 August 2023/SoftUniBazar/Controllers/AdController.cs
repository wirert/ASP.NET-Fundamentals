namespace SoftUniBazar.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Entities;
    using Models;
    using static Constants.DataConstants.Ad;

    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext dbContext;

        public AdController(BazarDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            return RedirectPermanent("/ad/all");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await dbContext.Ads
                .Select(a => new AllAdModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Category = a.Category.Name,
                    CreatedOn = a.CreatedOn.ToString(DateTimeFormat),
                    ImageUrl = a.ImageUrl,
                    Owner = a.Owner.UserName,
                    Price = a.Price
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AdFormModel()
            {
                Categories = await GetCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormModel model)
        {
            var categories = await GetCategoriesAsync();

            if (categories.All(c => c.Id != model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Invalid category");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategoriesAsync();
                return View(model);
            }

            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                OwnerId = GetUserId(),
                Price = model.Price
            };

            dbContext.Ads.Add(ad);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ad = await dbContext.Ads.FindAsync(id);

            if (ad == null || ad.OwnerId != GetUserId())
            {
                return RedirectToAction("All");
            }

            var model = new AdFormModel()
            {
                Name = ad.Name,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,
                Categories = await GetCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdFormModel model)
        {
            var categories = await GetCategoriesAsync();

            if (categories.All(c => c.Id != model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Invalid category");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategoriesAsync();
                return View(model);
            }

            var ad = await dbContext.Ads.FindAsync(id);

            if (ad == null)
            {
                return NotFound();
            }

            if (ad.OwnerId != GetUserId())
            {
                return BadRequest();
            }

            ad.Name = model.Name;
            ad.Description = model.Description;
            ad.ImageUrl = model.ImageUrl;
            ad.Price = model.Price;
            ad.CategoryId = model.CategoryId;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var ad = await dbContext.Ads.FindAsync(id);

            if (ad == null)
            {
                return NotFound();
            }

            var userId = GetUserId();

            if (ad.OwnerId == userId)
            {
                return BadRequest();
            }

            var adBuyer = new AdBuyer()
            {
                AdId = id,
                BuyerId = userId
            };

            var isAlreadyAdded = await dbContext
                .AdsBuyers
                .AnyAsync(ab => ab.BuyerId == userId && ab.AdId == id);

            if (isAlreadyAdded)
            {
                return RedirectToAction("All");
            }

            dbContext.AdsBuyers.Add(adBuyer);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Cart");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var userId = GetUserId();

            var model = await dbContext.AdsBuyers
                .AsNoTracking()
                .Where(ab => ab.BuyerId == userId)
                .Select(ab => new AllAdModel()
                {
                    Name = ab.Ad.Name,
                    Description = ab.Ad.Description,
                    CreatedOn = ab.Ad.CreatedOn.ToString(DateTimeFormat),
                    Category = ab.Ad.Category.Name,
                    ImageUrl = ab.Ad.ImageUrl,
                    Price = ab.Ad.Price,
                    Owner = ab.Ad.Owner.UserName,
                    Id = ab.Ad.Id
                })
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var adBuyer = await dbContext
                        .AdsBuyers
                        .Where(ab => ab.AdId == id &&
                                     ab.BuyerId == GetUserId())
                        .FirstOrDefaultAsync();

            if (adBuyer == null)
            {
                return NotFound();
            }

            dbContext.AdsBuyers.Remove(adBuyer);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("All");
        }

        private async Task<IEnumerable<CategorySelectModel>> GetCategoriesAsync()
        {
            return await dbContext.Categories
                .Select(c => new CategorySelectModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
