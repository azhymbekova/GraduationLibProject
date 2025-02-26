﻿using LibraryProject.Data.Entity;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } 

    public List<BorrowBook> BorrowedBooks { get; set; } = new List<BorrowBook>();
}
