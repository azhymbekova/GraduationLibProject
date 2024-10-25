using LibraryProject.BL.Models;
using LibraryProject.Data;
using LibraryProject.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly LibraryContext _context;

    public AuthController(IConfiguration configuration, LibraryContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel login)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == login.Username && u.Password == login.Password);

        if (user == null)
        {
            return Unauthorized("Неверные имя пользователя или пароль.");
        }

        var token = GenerateJwtToken(user);
        return Ok(new { Token = token });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterModel registerModel)
    {
        if (registerModel == null || string.IsNullOrEmpty(registerModel.Username) || string.IsNullOrEmpty(registerModel.Password))
        {
            return BadRequest("Пожалуйста, укажите имя пользователя и пароль.");
        }

        // Проверка на существование пользователя
        var existingUser = _context.Users.SingleOrDefault(u => u.Username == registerModel.Username);
        if (existingUser != null)
        {
            return Conflict("Пользователь с таким именем уже существует.");
        }

        // Хэширование пароля
        var hashedPassword = HashPassword(registerModel.Password);

        var user = new User
        {
            Username = registerModel.Username,
            Password = hashedPassword,
            Role = "user"
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Login), new { username = user.Username }, user);
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
