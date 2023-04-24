using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmps.Interfaces;
using tmps.Products;

namespace tmps
{
    public class EnglishBookBuilder : IBookBuilder
{
    private string _title;
    private string _author;
    private string _id;
    private Genre _genre;
    private Language _language;

        public IBookBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }

    public IBookBuilder SetAuthor(string author)
    {
        _author = author;
        return this;
    }

    public IBookBuilder SetId(string id)
    {
        _id = id;
        return this;
    }

    public IBookBuilder SetGenre(Genre genre)
    {
        _genre = genre;
        return this;
    }

    public IBookBuilder SetLanguage(Language language)
    {
        _language = language;
        return this;
    }

    public Book Build()
    {
        if (string.IsNullOrEmpty(_title))
        {
            throw new InvalidOperationException("Title cannot be empty");
        }

        if (string.IsNullOrEmpty(_author))
        {
            throw new InvalidOperationException("Author cannot be empty");
        }

        if (string.IsNullOrEmpty(_id))
        {
            throw new InvalidOperationException("id cannot be empty");
        }

        return new EnglishBook
        {
            Title = _title,
            Author = _author,
            Id = _id,
            Genre = _genre.ToString(),
            Language = _language.ToString()
        };

    }

        public IBookBuilder SetGenre(string Genre)
        {
            throw new NotImplementedException();
        }

        public IBookBuilder SetLanguage(string Language)
        {
            throw new NotImplementedException();
        }
    }


    public enum Genre
    {
        Novel,
        Poetry,
        Drama,
        NonFiction
    }

    public enum Language
    {
        English,
        French,
        Spanish,
        German
    }
}
