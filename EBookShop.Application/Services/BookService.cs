using AutoMapper;
using EBookShop.Application.Command;
using EBookShop.Application.Dto;
using EBookShop.Application.IServices;
using EBookShop.Core.Entities;
using MediatR;

namespace EBookShop.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        //call mediatory for get all books
        public async Task<List<Book>> GetBooks()
        {
            GetBooksQuery command = new GetBooksQuery();
            var queryresult = await _mediator.Send(command);
            var result = _mapper.Map<List<Book>>(queryresult);
            return result;
        }

        //call mediatory for insert books
        public async Task<int> InsertBook(Book book)
        {
            BookEntity bookEntity = new BookEntity();
            bookEntity = _mapper.Map<BookEntity>(book);
            CreateBookCommand command = new CreateBookCommand() { payload = bookEntity };
            var result = await _mediator.Send(command);
            return result;
        }

        //call mediatory for update books
        public async Task<bool> UpdateBook(Book book)
        {
            BookEntity bookEntity = new BookEntity();
            bookEntity = _mapper.Map<BookEntity>(book);
            UpdateBookCommand command = new UpdateBookCommand() { payload = bookEntity };
            var result = await _mediator.Send(command);
            return result;
        }

        //call mediatory for delete books
        public async Task<bool> DeleteBook(int id)
        {
            BookEntity bookEntity = new BookEntity();
            bookEntity.Id = id;
            DeleteBookCommand command = new DeleteBookCommand() { payload = bookEntity };
            var result = await _mediator.Send(command);
            return result;
        }

        //call mediatory for get books
        public async Task<Book> GetBookById(int BookId)
        {

            GetBookQuery command = new GetBookQuery() { BookId = BookId };
            var queryresult = await _mediator.Send(command);
            var result = _mapper.Map<Book>(queryresult);
            return result;
        }

    }

}
