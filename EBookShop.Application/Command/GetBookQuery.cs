using EBookShop.Core.Entities;
using MediatR;

namespace EBookShop.Application.Command
{
    public class GetBookQuery : IRequest<BookEntity>
    {
        public int BookId { get; set; }
    }
}
