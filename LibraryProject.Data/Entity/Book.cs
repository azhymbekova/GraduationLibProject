
namespace LibraryProject.Data.Entity;
public class Book 
{
    public long Id { get; set; }
    public string BookName { get; set; }
    public string BookDescription { get; set; }
    public string BookAuthors { get; set; }
    public string Title { get; set; }
    public DateTime BookDateTime { get; set; }
    public int AmountPages { get; set; }
    public int Rating { get; set; }
    public string Genre { get; set; }
    public Library? Library { get; set; }
    public long? LibraryId { get; set; }


    public List<BorrowBook> BorrowBooks { get; set; }
}
