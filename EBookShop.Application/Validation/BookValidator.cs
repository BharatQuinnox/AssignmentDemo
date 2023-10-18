using EBookShop.Application.Dto;
using FluentValidation;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(book => book.Title)
            .NotEmpty().WithMessage("Title is required");

        RuleFor(book => book.Author)
            .NotEmpty().WithMessage("Author is required");

        RuleFor(book => book.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(book => book.ISBN)
            .NotEmpty().WithMessage("ISBN is required")
            .Must(BeAValidISBN).WithMessage("Invalid ISBN format");

    }

    private bool BeAValidISBN(string isbn)
    {
        isbn = isbn.Replace("-", "");
        return isbn.Length == 13 || isbn.Length==10;
    }
}
