using LibraryProject.BL.Interfaces;
using LibraryProject.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks(string search, string genre, string sortBy)
        {
            var books = _context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                books = books.Where(b => b.BookName.Contains(search) || b.BookDescription.Contains(search));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                books = books.Where(b => b.Genre == genre);
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                books = sortBy.ToLower() switch
                {
                    "name" => books.OrderBy(b => b.BookName),
                    "date" => books.OrderBy(b => b.BookDateTime),
                    "rating" => books.OrderBy(b => b.Rating),
                    _ => books
                };
            }

            return books.ToList();
        }

        public Book GetBookById(long id) => _context.Books.Find(id);

        public Book AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(long id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
