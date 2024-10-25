using LibraryProject.Data.Interfaces;
using LibraryProject.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAllUsers() => Ok(_userService.GetAllUsers());

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        return user == null ? NotFound() : Ok(user);
    }

    // Получение профиля текущего пользователя
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        var userId = int.Parse(User.Claims.First(c => c.Type == "sub").Value);
        var user = _userService.GetUserById(userId);
        if (user == null) return NotFound("Пользователь не найден.");

        var userDto = new { user.Id, user.Username, user.Email };
        return Ok(userDto);
    }

    // Обновление профиля текущего пользователя
    [HttpPut("update-profile")]
    public IActionResult UpdateProfile([FromBody] UpdateProfileModel model)
    {
        var userId = int.Parse(User.Claims.First(c => c.Type == "sub").Value);
        var user = _userService.GetUserById(userId);
        if (user == null) return NotFound("Пользователь не найден.");

        user.Email = model.Email;
        user.Password = model.Password;
        _userService.UpdateUser(user);
        return Ok("Профиль обновлен.");
    }

    // Получение истории взятых и возвращенных книг
    [HttpGet("borrow-history")]
    public IActionResult GetBorrowHistory()
    {
        var userId = int.Parse(User.Claims.First(c => c.Type == "sub").Value);
        var history = _userService.GetBorrowHistory(userId);
        return Ok(history);
    }

    // Получение списка книг, которые пользователь взял и читает в данный момент
    [HttpGet("current-books")]
    public IActionResult GetCurrentBooks()
    {
        var userId = int.Parse(User.Claims.First(c => c.Type == "sub").Value);
        var currentBooks = _userService.GetCurrentBooks(userId);
        return Ok(currentBooks);
    }

    // Возврат книги, которую пользователь взял
    [HttpPost("return-book/{id}")]
    public IActionResult ReturnBook(long id)
    {
        var userId = int.Parse(User.Claims.First(c => c.Type == "sub").Value);
        var success = _userService.ReturnBook(userId, id);
        if (!success) return NotFound("Книга не найдена или не была взята пользователем.");
        return Ok("Книга успешно возвращена.");
    }

    // Изменение роли пользователя (доступно только администратору)
    [HttpPut("change-role/{id}")]
    public IActionResult ChangeUserRole(int id, [FromBody] string newRole)
    {
        if (User.Claims.FirstOrDefault(c => c.Type == "role")?.Value != "admin")
        {
            return Forbid("Доступ только для администратора.");
        }
        var user = _userService.GetUserById(id);
        if (user == null) return NotFound("Пользователь не найден.");
        user.Role = newRole;
        _userService.UpdateUser(user);
        return Ok("Роль пользователя успешно изменена.");
    }
}
