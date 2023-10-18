using EBookShop.Core.Entities;

namespace EBookShop.Core.Interfaces
{
    public interface IBookRepository
    {
         Task<List<BookEntity>> GetBooks();

        Task<BookEntity> GetBookById(int BookId);
        Task<int> InsertBook(BookEntity bookEntity);
        Task<bool> UpdateBook(BookEntity bookEntity);
        Task<bool> Delete(int BookId);


    }
}
