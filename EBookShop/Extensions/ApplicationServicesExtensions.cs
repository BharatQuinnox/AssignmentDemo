using EBookShop.Application.Command.Handler;
using EBookShop.Application.IServices;
using EBookShop.Application.Services;
using EBookShop.Core.Interfaces;
using EBookShop.Infrastructure.ConnectionFactory;
using EShop.Application.AutoMapper;
using EShop.Infrastructure.Repositories;
using FluentValidation;
using MediatR;

namespace EShop.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateBookCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateBookCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetBookQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetBooksQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteBookCommandHandler).Assembly));
            services.AddAutoMapper(typeof(ApplicationMapper));
            services.AddScoped<IDbConnectionFactory, SqlDBConnectionFactory>();
            services.AddValidatorsFromAssemblyContaining<BookValidator>();
            return services;
        }
    }
}
