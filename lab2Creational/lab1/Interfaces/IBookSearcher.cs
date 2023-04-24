using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps
{
    public interface IBookSearcher
    {
        List<Book> Search(List<Book> books, string query);
    }
}
