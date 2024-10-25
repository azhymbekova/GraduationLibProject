using LibraryProject.Data.Entity;
using System.Collections.Generic;

namespace LibraryProject.Data.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);

        // истории книг
        IEnumerable<BorrowBook> GetBorrowHistory(int userId);

        //текущих книг
        IEnumerable<BorrowBook> GetCurrentBooks(int userId);

        // возврат книг
        bool ReturnBook(int userId, long bookId);
    }
}
