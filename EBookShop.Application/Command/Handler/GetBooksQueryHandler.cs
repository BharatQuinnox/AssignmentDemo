using EBookShop.Core.Entities;
using EBookShop.Core.Interfaces;
using MediatR;

namespace EBookShop.Application.Command.Handler
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<BookEntity>>
    {
        private readonly IBookRepository _bookRepository;
        public GetBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //call repository for Get books
        public Task<List<BookEntity>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var result = _bookRepository.GetBooks();
            return result;
        }
    }
}
