using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps.Interfaces
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        List<Book> GetAllBooks();
    }
}
