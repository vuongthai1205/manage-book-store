using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace backend
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ODataController
    {
        private readonly IBookService bookService;
        private readonly IRabbitMQService rabbitMQService;

        public BookController(IBookService _bookService, IRabbitMQService rabbitMQService)
        {
            bookService = _bookService;
            this.rabbitMQService = rabbitMQService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books = await bookService.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            Book book = await bookService.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(BookRequest book)
        {
            await bookService.InsertBookAsync(book);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, BookRequest book)
        {
            await bookService.UpdateBook(id, book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var category = await bookService.GetBookByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await bookService.DeleteBook(id);

            return NoContent();
        }
    }
}
