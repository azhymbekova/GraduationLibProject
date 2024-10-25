using LibraryProject.BL.Interfaces;
using LibraryProject.BL.Dtos;
using LibraryProject.Data.Entity;

namespace LibraryProject.BL.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public BookDto AddBook(BookDto bookDto)
        {
            var book = new Book
            {
                BookName = bookDto.BookName,
                BookDescription = bookDto.BookDescription,
                AmountPages = bookDto.AmountPages,
                LibraryId = bookDto.LibraryId,
                BookDateTime = bookDto.BookDateTime,
            };

            var addedBook = _bookRepository.AddBook(book);
            return new BookDto
            {
                BookName = addedBook.BookName,
                BookDescription = addedBook.BookDescription,
                AmountPages = addedBook.AmountPages,
                LibraryId = addedBook.LibraryId.HasValue ? (int?)Convert.ToInt32(addedBook.LibraryId.Value) : null,
                BookDateTime = addedBook.BookDateTime,
            };
        }

        public IEnumerable<BookDto> GetBooks()
        {
            var books = _bookRepository.GetAllBooks("", "", "");
            return books.Select(b => new BookDto
            {
                BookName = b.BookName,
                BookDescription = b.BookDescription,
                AmountPages = b.AmountPages,
                LibraryId = b.LibraryId.HasValue ? (int?)Convert.ToInt32(b.LibraryId.Value) : null,
                BookDateTime = b.BookDateTime,
            });
        }

        public void DeleteBook(long id) => _bookRepository.DeleteBook(id);

        public BookDto UpdateBook(long id, BookDto bookDto)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null) throw new Exception("Книга не найдена");

            book.BookName = bookDto.BookName;
            book.BookDescription = bookDto.BookDescription;
            book.AmountPages = bookDto.AmountPages;
            book.LibraryId = bookDto.LibraryId;
            book.BookDateTime = bookDto.BookDateTime;

            _bookRepository.UpdateBook(book);

            return new BookDto
            {
                BookName = book.BookName,
                BookDescription = book.BookDescription,
                AmountPages = book.AmountPages,
                LibraryId = book.LibraryId.HasValue ? (int?)Convert.ToInt32(book.LibraryId.Value) : null,
                BookDateTime = book.BookDateTime,
            };
        }
        public BookDto GetBookById(long id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null) return null; 

            return new BookDto(book); 
        }

    }
}
