using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps.Interfaces
{
    public interface IBookFactory
    {
        Book CreateBook(string title, string author, string id);
    }
}
