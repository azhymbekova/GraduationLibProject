using LibraryProject.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class MainMenuController : ControllerBase
{
    private readonly LibraryContext _context;

    public MainMenuController(LibraryContext context)
    {
        _context = context;
    }

    // Перенаправление в личный кабинет
    [HttpGet("cabinet")]
    public IActionResult GoToUserCabinet()
    {
        return Redirect("/api/UserCabinet");
    }

    // Метод для поиска и сортировки книг
    [HttpGet("search-books")]
    public IActionResult SearchBooks(string searchTerm = "", string sortBy = "")
    {
        var books = _context.Books.AsQueryable();

        // Поиск по названию и автору
        if (!string.IsNullOrEmpty(searchTerm))
        {
            books = books.Where(b => b.Title.Contains(searchTerm) || b.BookAuthors.Contains(searchTerm));
        }

        // Сортировка по жанру, автору, дате выхода
        if (!string.IsNullOrEmpty(sortBy))
        {
            books = sortBy.ToLower() switch
            {
                "title" => books.OrderBy(b => b.Title),
                "author" => books.OrderBy(b => b.BookAuthors),
                _ => books
            };
        }

        return Ok(books.ToList());
    }
}
