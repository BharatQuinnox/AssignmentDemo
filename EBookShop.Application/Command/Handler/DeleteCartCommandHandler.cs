using EBookShop.Core.Interfaces;
using MediatR;

namespace EBookShop.Application.Command.Handler
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        public readonly IBookRepository _bookRepository;
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //call repository for Delete book
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await _bookRepository.Delete(request.payload.Id);
        }
    }
}
