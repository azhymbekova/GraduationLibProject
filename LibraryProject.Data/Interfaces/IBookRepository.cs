using LibraryProject.Data.Entity;

namespace LibraryProject.BL.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks(string search, string genre, string sortBy);
        Book GetBookById(long id);
        Book AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(long id);
    }
}
