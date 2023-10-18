using EBookShop.Application.Dto;

namespace EBookShop.Application.IServices
{
    public interface IBookService
    {
        Task<int> InsertBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
        Task<List<Book>> GetBooks();

        Task<Book> GetBookById(int id);

    }
}
