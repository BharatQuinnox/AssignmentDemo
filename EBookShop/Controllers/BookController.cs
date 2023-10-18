using EBookShop.Application.Dto;
using EBookShop.Application.IServices;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace EShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private ILogger<BookController> _logger;
        private IBookService _bookService;
        private IValidator<Book> _validator;
 
        public BookController(ILogger<BookController> logger, 
                              IBookService bookService, 
                              IValidator<Book> validator)
        {
            _logger = logger;
            _bookService = bookService;
            _validator = validator;
        }
        //retireve all books
        [HttpGet]
        public async Task<List<Book>> Get()
        {
            return await _bookService.GetBooks();
        }
        //This code used to get book by id
        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await _bookService.GetBookById(id);
        }
        // create book
        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Book book)
        {
            _logger.LogInformation("Start Processing book addding");

            var result = await _validator.ValidateAsync(book);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            var bookId = await _bookService.InsertBook(book);
            _logger.LogInformation("End Processing book addding");
            return CreatedAtAction(nameof(Post), new { id = bookId }, new { CreatedId = bookId });

        }
        // update book
        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Book book)
        {
            _logger.LogInformation("Start Processing book addding");

            var result = await _validator.ValidateAsync(book);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            var updateresult = await _bookService.UpdateBook(book);
            return CreatedAtAction(nameof(Put), new { id = result }, new { Updated = updateresult });
        }
        //delete book
        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var result = await _bookService.DeleteBook(id);
            return CreatedAtAction(nameof(Delete), new { id = result }, new { Deleted = result });
        }
    }
}
