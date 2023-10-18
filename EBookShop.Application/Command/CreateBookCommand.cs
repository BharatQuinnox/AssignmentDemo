using EBookShop.Core.Entities;
using MediatR;

namespace EBookShop.Application.Command
{
    public class CreateBookCommand : IRequest<int>
    {
       public  BookEntity payload { get; set; }
    }
}
