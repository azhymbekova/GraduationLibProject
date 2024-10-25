using LibraryProject.Data.Entity;

namespace LibraryProject.BL.Dtos
{
    public class BookDto
    {
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public int AmountPages { get; set; } 
        public int? LibraryId { get; set; }
        public DateTime BookDateTime { get; set; }
        public BookDto(Book book)
        {
            BookName = book.BookName;
            BookDescription = book.BookDescription;
            AmountPages = book.AmountPages;
            LibraryId = book.LibraryId.HasValue ? (int?)Convert.ToInt32(book.LibraryId.Value) : null;
            BookDateTime = book.BookDateTime;
        }

        public BookDto() { }
    }
}
