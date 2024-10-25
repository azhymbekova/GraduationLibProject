using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Data.Entity
{
    public class BorrowBook
    {
        public long Id { get; set; }
        public long BorrowId { get; set; }
        public long BookId { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }
        public Book Book { get; set; }
       
        public User User { get; set; }
    }
}
