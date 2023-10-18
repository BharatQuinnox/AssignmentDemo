using EBookShop.Core.Entities;
using EBookShop.Core.Interfaces;
using MediatR;

namespace EBookShop.Application.Command.Handler
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookEntity>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //call repository for Get book
        public async Task<BookEntity> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
           return await _bookRepository.GetBookById(request.BookId);
        }
    }
}
