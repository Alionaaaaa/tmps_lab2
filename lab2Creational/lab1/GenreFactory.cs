using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmps.Products;
using tmps.Interfaces;

namespace tmps
{
    public class GenreFactory : IBookGenreFactory
    {
        public Book CreateNovel(string title, string author, string id)
        {
            return new Novel
            {
                Title = title,
                Author = author,
                Id = id
            };
        }

        public Book CreateShortStory(string title, string author, string id)
        {
            // arunca o exceptie sau returneaza null deoarece aceasta fabrica nu poate crea obiecte de tip ShortStory
            throw new NotSupportedException();
        }
        // alte metode de creare a cărților
    }

   

}
