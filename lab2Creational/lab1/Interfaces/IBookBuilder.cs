using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static tmps.LanguageBookFactory;

namespace tmps.Interfaces
{
    public interface IBookBuilder
    {
        IBookBuilder SetTitle(string title);
        IBookBuilder SetAuthor(string author);
        IBookBuilder SetId(string id);
        IBookBuilder SetGenre(string genre);
        IBookBuilder SetLanguage(string language);
        Book Build();

    }
}
