using EBookShop.Core.Entities;
using MediatR;

namespace EBookShop.Application.Command
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public BookEntity payload { get; set; }

    }
}
