using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmps.Interfaces;

namespace tmps
{
    public class Library
    {
        private readonly IBookRepository _bookRepository;
       // private readonly IBookSearcher _bookSearcher;
        private readonly IBookFactory _bookFactory;
        private readonly IBookLanguageFactory _bookLanguageFactory;

        public Library(IBookRepository bookRepository, IBookFactory bookFactory, IBookLanguageFactory bookLanguageFactory)
        {
            _bookRepository = bookRepository;
           // _bookSearcher = bookSearcher;
            _bookFactory = bookFactory;
            _bookLanguageFactory = bookLanguageFactory;
        }

        public void AddBook(string title, string author, string id)
        {
            Book book = _bookFactory.CreateBook(title, author, id);
            _bookRepository.AddBook(book);
        }

        internal List<Book> SearchBooks(string v)
        {
            throw new NotImplementedException();
        }

        //   public List<Book> SearchBooks(string query)
        //  {
        //    List<Book> books = _bookRepository.GetAllBooks();
        //        return _bookSearcher.Search(books, query);
        //}
    }
}
