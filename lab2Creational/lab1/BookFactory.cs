using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmps.Interfaces;

namespace tmps
{
    public class BookFactory : IBookFactory
    {
        public Book CreateBook(string title, string author, string id)
        {
            return new Book
            {
                Title = title,
                Author = author,
                Id = id
            };
        }
    }
}
