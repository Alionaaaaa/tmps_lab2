using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmps.Interfaces;

namespace tmps
{
    public class BookRepository : IBookRepository
    {
        private static BookRepository _instance; //Creăm o instanță privată statică

        private List<Book> _books = new List<Book>();


        private BookRepository() //constructor 
        {
            _books = new List<Book>();
        }

// Creați o metodă publică statică pentru a obține instanța
        public static BookRepository Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BookRepository();
                }
                return _instance;
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }
    }
}
