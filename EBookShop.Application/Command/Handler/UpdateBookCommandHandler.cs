using AutoMapper;
using EBookShop.Core.Interfaces;
using MediatR;

namespace EBookShop.Application.Command.Handler
{

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        //call repository for update book
        public Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var result = _bookRepository.UpdateBook(request.payload);
            return result;
        }
    }
}
