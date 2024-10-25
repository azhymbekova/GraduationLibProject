using LibraryProject.Data.Entity;

public class Library
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public List<Book> Books { get; set; }
    public List<User> Users { get; set; }
}
