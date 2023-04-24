using tmps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps
{
    public interface IBookLanguageFactory
    {
        Book CreateBookInEnglish(string title, string author, string id);
        Book CreateBookInFrench(string title, string author, string id);
        // alte metode de creare a cărților în diferite limbi
    }
}
