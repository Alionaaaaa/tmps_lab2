using tmps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmps.Interfaces
{
    public interface IBookGenreFactory
    {
        Book CreateNovel(string title, string author, string id);
        Book CreateShortStory(string title, string author, string id);
        // alte metode de creare a cărților
    }
}
