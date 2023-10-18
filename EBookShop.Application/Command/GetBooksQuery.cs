using EBookShop.Core.Entities;
using MediatR;

namespace EBookShop.Application.Command
{
    public class GetBooksQuery : IRequest<List<BookEntity>>
    {
    }
}
