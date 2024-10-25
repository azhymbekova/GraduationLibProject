﻿using LibraryProject.Data.Entity; // Подключаем BorrowBook и другие сущности
using LibraryProject.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Data
{
    public class UserRepository : IUserService
    {
        private readonly LibraryContext _context;

        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers() => _context.Users.ToList();

        public User GetUserById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<BorrowBook> GetBorrowHistory(int userId)
        {
            return _context.BorrowBooks.Where(b => b.UserId == userId).ToList();
        }

        public IEnumerable<BorrowBook> GetCurrentBooks(int userId)
        {
            return _context.BorrowBooks.Where(b => b.UserId == userId && !b.IsReturned).ToList();
        }

        public bool ReturnBook(int userId, long bookId)
        {
            var borrowRecord = _context.BorrowBooks.FirstOrDefault(b => b.UserId == userId && b.BookId == bookId && !b.IsReturned);
            if (borrowRecord == null)
            {
                return false; // Книга не найдена или уже возвращена
            }

            borrowRecord.IsReturned = true;
            _context.BorrowBooks.Update(borrowRecord);
            _context.SaveChanges();
            return true;
        }
    }
}
