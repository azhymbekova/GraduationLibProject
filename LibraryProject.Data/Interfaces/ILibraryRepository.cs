using LibraryProject.Data.Entity;
using System.Collections.Generic;

namespace LibraryProject.Data.Repository
{
    public interface ILibraryRepository
    {
        Library Add(Library library); 
        Library GetById(int id); 
        List<Library> GetAll(); 
        void Update(Library library); 
        void Delete(Library library);
    }
}
