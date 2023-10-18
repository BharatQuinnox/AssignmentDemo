using AutoMapper;
using EBookShop.Application.Dto;
using EBookShop.Core.Entities;
using EBookShop.Infrastructure.DataModel;

namespace EShop.Application.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<BookDataModel, BookEntity>().ReverseMap();
            CreateMap<Book, BookEntity>().ReverseMap();
        }
    }
}
    

