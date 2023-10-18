using EBookShop.Core.Entities;
using MediatR;

namespace EBookShop.Application.Command
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public BookEntity payload { get; set; }
    }
}
