using LibraryProject.BL.Dtos;
using LibraryProject.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _service;

        public BookController(BookService service)
        {
            _service = service;
        }

        // Добавление книги - доступно только администратору
        [HttpPost("add-book")]
        [Authorize(Roles = "admin")]
        public IActionResult AddBook([FromBody] BookDto book)
        {
            var addedBook = _service.AddBook(book);
            return Ok(addedBook);
        }

        // Получение всех книг - доступно всем пользователям
        [HttpGet("get-books")]
        public IActionResult GetBooks()
        {
            var books = _service.GetBooks();
            if (books.Count() == 0)
                return NotFound();
            return Ok(books);
        }

        // Удаление книги - доступно только администратору
        [HttpDelete("delete-book/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteBook(long id)
        {
            try
            {
                _service.DeleteBook(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Обновление книги - доступно только администратору
        [HttpPut("update-book/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateBook(long id, [FromBody] BookDto bookDto)
        {
            try
            {
                var updatedBook = _service.UpdateBook(id, bookDto);
                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Получение книги по ID - доступно всем пользователям
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _service.GetBookById(id);

            if (book == null) return NotFound("Книга не найдена.");

            return Ok(book);
        }
    }
}
