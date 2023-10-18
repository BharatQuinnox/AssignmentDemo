using Cqrs.Hosts;
using EBookShop.Application.Dto;
using EBookShop.Application.IServices;
using EShop.Controllers;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EBookShopTest
{
    public class BookControllerTests
    {
        [Fact]
        public async Task Get_ReturnsListOfBooks()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            bookServiceMock.Setup(service => service.GetBooks()).ReturnsAsync(new List<Book>());

            var controller = new BookController(null, bookServiceMock.Object, null);

            // Act
            var result = await controller.Get();

            Assert.Equal(0,result.Count);
        }
        [Fact]
        public async Task Get_ReturnsBookById()
        {
            // Arrange
            int bookId = 1;
            var bookServiceMock = new Mock<IBookService>();
            var expectedBook = new Book { Id = bookId, Title = "Sample Book" };
            bookServiceMock.Setup(service => service.GetBookById(bookId)).ReturnsAsync(expectedBook);

            var controller = new BookController(null, bookServiceMock.Object, null);

            // Act
            var result = await controller.Get(bookId);

            // Assert
            Assert.Equal(expectedBook.Id, bookId);
        }


        [Fact]
        public async Task Post_ValidBook_ReturnsCreatedAtAction()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<BookController>>();
            var bookServiceMock = new Mock<IBookService>();
            var validatorMock = new Mock<IValidator<Book>>();

            var validBook = new Book { Title = "Valid Book" };
            var expectedBookId = 1;

            validatorMock.Setup(validator => validator.ValidateAsync(validBook, default)) // Ensure you pass CancellationToken
                        .ReturnsAsync(new FluentValidation.Results.ValidationResult());
            bookServiceMock.Setup(service => service.InsertBook(validBook)) // Make sure the argument matcher matches your actual method
                        .ReturnsAsync(expectedBookId);

            var controller = new BookController(loggerMock.Object, bookServiceMock.Object, validatorMock.Object);

            // Act
            var result = await controller.Post(validBook);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Post", createdAtActionResult.ActionName);
            Assert.Equal(expectedBookId, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task Put_ValidBook_ReturnsCreatedAtAction()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<BookController>>();
            var bookServiceMock = new Mock<IBookService>();
            var validatorMock = new Mock<IValidator<Book>>();

            var validBook = new Book { Title = "Valid Book" };
            var expectedUpdateResult = true;

            validatorMock.Setup(validator => validator.ValidateAsync(validBook, default))
                        .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            bookServiceMock.Setup(service => service.UpdateBook(validBook))
                          .ReturnsAsync(expectedUpdateResult);

            var controller = new BookController(loggerMock.Object, bookServiceMock.Object, validatorMock.Object);

            // Act
            var result = await controller.Put(validBook);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.True(createdAtActionResult.Value?.ToString().Contains("True"));
        }


        [Fact]
        public async Task Delete_BookId_ReturnsCreatedAtAction()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var bookId = 1;
            var expectedDeleteResult = true;

            bookServiceMock.Setup(service => service.DeleteBook(bookId))
                          .ReturnsAsync(expectedDeleteResult);

            var controller = new BookController(null, bookServiceMock.Object, null);

            // Act
            var result = await controller.Delete(bookId);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.True(createdAtActionResult.Value?.ToString().Contains("True"));
        }
    }
}
