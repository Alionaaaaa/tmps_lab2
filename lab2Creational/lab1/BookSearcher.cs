using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps
{
    public class TitleSearcher : IBookSearcher
    {
        public List<Book> Search(List<Book> books, string query)
        {
            List<Book> result = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Title.Contains(query))
                {
                    result.Add(book);
                }
            }
            return result;
        }
    }

    public class AuthorSearcher : IBookSearcher
    {
        public List<Book> Search(List<Book> books, string query)
        {
            List<Book> result = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Author.Contains(query))
                {
                    result.Add(book);
                }
            }
            return result;
        }
    }


}
