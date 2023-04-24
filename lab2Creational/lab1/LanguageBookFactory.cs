using tmps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmps.Products;

namespace tmps
{
    public class LanguageBookFactory : IBookLanguageFactory
    {
        public Book CreateBookInEnglish(string title, string author, string id)
        {
            return new EnglishBook
            {
                Title = title,
                Author = author,
                Id = id
            };
        }

        public Book CreateBookInFrench(string title, string author, string id)
        {
            // arunca o exceptie sau returneaza null deoarece aceasta fabrica nu poate crea obiecte de tip FrenchBook
            throw new NotSupportedException();
        }

        // alte metode de creare a cărților în alte limbi

    }
}
