using Microsoft.EntityFrameworkCore;

using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models.Book;
using Library.Models.Category;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task AddNewBookAsync(AddBookViewModel viewModel)
        {
            var book = new Book()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                Author = viewModel.Author,
                CategoryId = viewModel.CategoryId,
                ImageUrl = viewModel.ImageUrl,
                Rating = viewModel.Rating
            };

            await context.AddAsync(book);
            await context.SaveChangesAsync();
        }       

        public async Task AddBookToCollection(string userId, BookViewModel viewModel)
        {
            bool isAdded = context.IdentityUsersBooks
                .Any(ub => ub.CollectorId == userId && ub.BookId == viewModel.Id);

            if (!isAdded)
            {
                await context.AddAsync(new IdentityUserBook()
                {
                    CollectorId = userId,
                    BookId = viewModel.Id
                });

                await context.SaveChangesAsync();
            }
        }

        public Task AddBookToCollection(string userId, AddBookViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<BookViewModel?> FindBookByIdAsync(int id)
        {
            return context.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Author = b.Author,
                    CategoryId = b.CategoryId,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<AllBookViewModel>> GetAllAsync()
        {
            return await context.Books
                .AsNoTracking()
                .Select(b => new AllBookViewModel()
                {
                    Id = b.Id,
                    Author = b.Author,
                    Title = b.Title,
                    Rating = b.Rating,
                    ImageUrl = b.ImageUrl,
                    Category = b.Category.Name
                })
                .ToListAsync();
        }

        public async Task<ICollection<CategoryViewModel>> GetCategoriesAsync()
        {
            return await context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<ICollection<MineBooksViewModel>> GetMineAsync(string userId)
        {
            return await context.IdentityUsersBooks
                 .AsNoTracking()
                 .Where(ub => ub.CollectorId == userId)
                 .Select(ub => new MineBooksViewModel()
                 {
                     Id = ub.Book.Id,
                     Author = ub.Book.Author,
                     Title = ub.Book.Title,
                     Description = ub.Book.Description,
                     ImageUrl = ub.Book.ImageUrl,
                     Category = ub.Book.Category.Name
                 })
                 .ToListAsync();
        }

        public async Task RemoveBookToCollection(string userId, BookViewModel model)
        {
            var userBook = await context.IdentityUsersBooks.FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == model.Id);

            if (userBook != null)
            {
                context.IdentityUsersBooks.Remove(userBook);
                await context.SaveChangesAsync();
            }
        }
    }
}
