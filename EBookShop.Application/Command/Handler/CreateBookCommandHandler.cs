using AutoMapper;
using EBookShop.Core.Interfaces;
using MediatR;

namespace EBookShop.Application.Command.Handler
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        //call repository for insert book
        public Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var result = _bookRepository.InsertBook(request.payload);
            return result;
        }
    }
}
