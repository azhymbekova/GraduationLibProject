using LibraryProject.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryContext _context;

        public LibraryRepository(LibraryContext context)
        {
            _context = context;
        }

        public Library Add(Library library)
        {
            _context.Libraries.Add(library);
            _context.SaveChanges();
            return library;
        }

        public Library GetById(int id)
        {
            return _context.Libraries.Find(id);
        }

        public List<Library> GetAll()
        {
            return _context.Libraries.ToList();
        }

        public void Update(Library library)
        {
            _context.Libraries.Update(library);
            _context.SaveChanges();
        }

        public void Delete(Library library)
        {
            _context.Libraries.Remove(library);
            _context.SaveChanges();
        }
    }
}
