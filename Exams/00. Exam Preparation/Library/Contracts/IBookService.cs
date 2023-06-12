using Library.Data.Models;
using Library.Models.Book;
using Library.Models.Category;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<ICollection<AllBookViewModel>> GetAllAsync();

        Task<ICollection<MineBooksViewModel>> GetMineAsync(string userId);

        Task AddNewBookAsync(AddBookViewModel viewModel);

        Task<BookViewModel?> FindBookByIdAsync(int id);

        Task AddBookToCollection(string userId, BookViewModel viewModel);

        Task RemoveBookToCollection(string userId, BookViewModel model);

        Task<ICollection<CategoryViewModel>> GetCategoriesAsync();
    }
}
