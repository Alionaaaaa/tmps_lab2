using System;
using System.Collections.Generic;
using tmps;
using tmps.Interfaces;
using tmps.Products;

class Program
{
    static void Main(string[] args)
    {
        // Create a new instance of the Library class
        IBookRepository bookRepository = BookRepository.Instance;
        IBookFactory bookFactory1 = new BookFactory();
        IBookLanguageFactory CreateBookInEnglish = new LanguageBookFactory();
        Library library = new Library(bookRepository, bookFactory1, CreateBookInEnglish);

        // Add some books to the library
        Book novel1 = new Novel { Title = "Cartea 1", Author = "Autor 1", Id = "11" };
        Book novel2 = new Novel { Title = "Cartea 2", Author = "Autor 2", Id = "22" };
        Book novel3 = new Novel { Title = "Cartea 3", Author = "Autor 3", Id = "33" };
        Book englishBook1 = new EnglishBook { Title = "English Book", Author = "Autor 4", Id = "123" };
        library.AddBook(novel1.Title, novel1.Author, novel1.Id);
        library.AddBook(novel2.Title, novel2.Author, novel2.Id);
        library.AddBook(novel3.Title, novel3.Author, novel3.Id);
        library.AddBook(englishBook1.Title, englishBook1.Author, englishBook1.Id);


        Novel n1 = new Novel();
        n1.Title = "The Great Gatsby";
        n1.Author = "F. Scott Fitzgerald";
        n1.Id = "222";
        n1.Genre = "Novel";
        n1.Language = "English";

        Novel n2 = n1.ShallowCopy();

        Console.WriteLine("info {0:s} {1:s} {2:s} {3:s} {4:s}", n1.Title, n1.Title, n1.Author, n1.Id, n1.Genre, n1.Language);
        Console.WriteLine("info {0:s} {1:s} {2:s} {3:s} {4:s}", n2.Title, n2.Title, n2.Author, n2.Id, n2.Genre, n2.Language);
    }

}
