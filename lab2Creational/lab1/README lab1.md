# lab1
 tmps

 -SOLID principles:
-Single Responsibility Principle		
-Open for Extension Closed for Modification	
-Liskov Substitution Principle	
-Interface Segregation Principle	
-Dependency Inversion	

#_____Single Responsibility Principle_____
#Def: Principiul Responsabilității Unice afirmă că o clasă ar trebui să aibă doar un motiv pentru a fi modificată.
#Prin alte cuvinte, o clasă trebuie să aibă doar o singură responsabilitate.


#bad way--------------------------------------------
#o metodă rea de a implementa SRP este de a combina responsabilitățile claselor Library, IBookRepository și IBookSearcher într-o singură clasă.

# Aceatsă clasă Library are atât responsabilitatea de a gestiona o colecție de obiecte Book, cât și de a căuta cărți în funcție de o interogare.

public class Library
{
    private readonly List<Book> _books;

    public Library()
    {
        _books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public List<Book> SearchBooks(string query)
    {
        List<Book> results = new List<Book>();

        foreach (Book book in _books)
        {
            if (book.Title.Contains(query) || book.Author.Contains(query))
            {
                results.Add(book);
            }
        }

        return results;
    }
}
#-------------------------------------------------------------------------------

#good way-----------------------------------------------------------------------
# de a separa responsabilitățile a claselor Library, IBookResponsability și IBookSearcher în clase separate.

public class Library
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookSearcher _bookSearcher;

        public Library(IBookRepository bookRepository, IBookSearcher bookSearcher)
        {
            _bookRepository = bookRepository;
            _bookSearcher = bookSearcher;
        }

        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);
        }

        public List<Book> SearchBooks(string query)
        {
            List<Book> books = _bookRepository.GetAllBooks();
            return _bookSearcher.Search(books, query);
        }
    }
}

public interface IBookRepository
    {
        void AddBook(Book book);
        List<Book> GetAllBooks();
    }

public interface IBookSearcher
    {
        List<Book> Search(List<Book> books, string query);
    }

public class BookRepository : IBookRepository
    {
        private List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }
    }

public class BookSearcher : IBookSearcher
    {
        public List<Book> Search(List<Book> books, string query)
        {
            return books.Where(b => b.Title.Contains(query) || b.Author.Contains(query) || b.ISBN.Contains(query)).ToList();
        }
    }
#-----------------------------------------------------------------------------------------



#_____Open for Extension Closed for Modification_____

#Prefer extension over modification.

#bad way-----------------------------------------------------------------------
#Clasa Library are două metode de a dăutare a cărților: searching by title și searching by author.
#Problema este că dacă va fi nevoie de a adăuga o nouă metodă de căutare, va trebui să modifică clasă.
#Astfel clasa va fi deschisă spre modificări ceea ce nu este admisibil pentru principiul Open-Closed!


public class Library
{
    private readonly List<Book> _books;

    public Library()
    {
        _books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public List<Book> SearchBooksByTitle(string title)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in _books)
        {
            if (book.Title.Contains(title))
            {
                result.Add(book);
            }
        }
        return result;
    }

    public List<Book> SearchBooksByAuthor(string author)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in _books)
        {
            if (book.Author.Contains(author))
            {
                result.Add(book);
            }
        }
        return result;
    }
}
#-----------------------------------------------------------------------------------------


#good way-----------------------------------------------------------------------
#O soluție mai bună este de a folosi conceptul de abstractizare, precum Interfațele.
#Astfel dacă vom vrea să adăugăm o nouă metodă de căutare a cărților, spre exeplu după Autor,
#atunci NU vom modifica alte părți ale programului, ci doar vom adăuga clasa nouă AuthorSearcher care va fi implementată de intefața IBookSearcher.

public interface IBookSearcher
{
    List<Book> Search(List<Book> books, string query);
}

public class TitleSearcher : IBookSearcher
{
    public List<Book> Search(List<Book> books, string query)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in books)
        {
            if (book.Title.Contains(query))
            {
                result.Add(book);
            }
        }
        return result;
    }
}

public class AuthorSearcher : IBookSearcher
{
    public List<Book> Search(List<Book> books, string query)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in books)
        {
            if (book.Author.Contains(query))
            {
                result.Add(book);
            }
        }
        return result;
    }
}

public class Library
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookSearcher _bookSearcher;

    public Library(IBookRepository bookRepository, IBookSearcher bookSearcher)
    {
        _bookRepository = bookRepository;
        _bookSearcher = bookSearcher;
    }

    public void AddBook(Book book)
    {
        _bookRepository.AddBook(book);
    }

    public List<Book> SearchBooks(string query)
    {
        List<Book> books = _bookRepository.GetAllBooks();
        return _bookSearcher.Search(books, query);
    }
}
#-----------------------------------------------------------------------------------------


#_____Liskov Substitution Principle_____

#Clasa derivată ar trebui să poată substitui clasa de bază. (polimorfism)
#override the method pentru un comportament diferit a metodei ;


#bad way-----------------------------------------------------------------------
#Metoda SearchBooks încalcă LSP prin faptul că se bazează atât pe proprietatea Title, cât și pe proprietatea Author a clasei Book. 
#Interfața IBookSearcher este proiectată pentru a efectua o căutare pe baza unui singur criteriu, fie Title, fie Author.
#Prin verificarea ambelor proprietăți în metoda SearchBooks, se încalcă principiul,  
#deoarece nu mai poate fi substituită pentru orice clasă care implementează interfața IBookSearcher.

namespace lab1
{
    public class Library
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookSearcher _bookSearcher;

        public Library(IBookRepository bookRepository, IBookSearcher bookSearcher)
        {
            _bookRepository = bookRepository;
            _bookSearcher = bookSearcher;
        }

        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);
        }

        public List<Book> SearchBooks(string query)
        {
            List<Book> books = _bookRepository.GetAllBooks();
            List<Book> result = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Title.Contains(query) || book.Author.Contains(query))
                {
                    result.Add(book);
                }
            }
            return result;
        }
    }
}
#-----------------------------------------------------------------------------------------


#good way-----------------------------------------------------------------------
#Această implementare respectă LSP, deoarece permite obiectelor claselor derivate (TitleSearcher și AuthorSearcher) 
#să fie substituite de obiecte ale clasei de bază (IBookSearcher) fără a afecta corectitudinea programului.

public interface IBookSearcher
    {
        List<Book> Search(List<Book> books, string query);
    }


public class TitleSearcher : IBookSearcher
    {
        public List<Book> Search(List<Book> books, string query)
        {
            List<Book> result = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Title.Contains(query))
                {
                    result.Add(book);
                }
            }
            return result;
        }
    }

public class AuthorSearcher : IBookSearcher
    {
        public List<Book> Search(List<Book> books, string query)
        {
            List<Book> result = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Author.Contains(query))
                {
                    result.Add(book);
                }
            }
            return result;
        }
    }


    static void Main(string[] args)
    {
        IBookSearcher bookSearcher1 = new TitleSearcher(); //here
        IBookSearcher bookSearcher2 = new AuthorSearcher(); //here

        Library library = new Library(bookRepository, bookSearcher2);

#-----------------------------------------------------------------------------------------



#_____Interface Segregation Principle_____

#Clientul nu trebuie să depindă de interfețe pe care nu le folosește.
#Interfața NU trebuie să aibă metode irelevante, ci trebuie să fie specifică pentru nevoile clientului.

#bad way-----------------------------------------------------------------------
public interface IBookSearcher
{
    List<Book> Search(List<Book> books, string query);
    void SaveSearchResults(List<Book> books); //este irelevantă, deoarece clientul NU trebuie să fie forțat 
                                        // să folosească metoda SaveSearchResults, pentru că nu are nevoie de ea
}
#-----------------------------------------------------------------------------------------


#good way-----------------------------------------------------------------------
public interface IBookSearcher
    {
        List<Book> Search(List<Book> books, string query);
    }
#-----------------------------------------------------------------------------------------



#_____Dependency Inversion_____

#modulele sau clasele de nivel ridicat nu ar trebui să depindă de modulele sau clasele de nivel scăzut,
#ci ambele ar trebui să depindă de abstractizări. 

#bad way-----------------------------------------------------------------------
#Încălacrea DIP, deoarece clasa Library nu ar trebui să depindă de detaliile de implementare ale claselor BookRepository

public class Library
{
    private readonly BookRepository _bookRepository; //Aici trebuia folosită dependența de o abstracție IBookRepository

    public Library()
    {
        _bookRepository = new BookRepository();
    }

    public void AddBook(Book book)
    {
        _bookRepository.AddBook(book);
    }

    public List<Book> SearchBooks(string query)
    {
        List<Book> books = _bookRepository.GetAllBooks();
        BookSearcher searcher = new BookSearcher();
        return searcher.Search(books, query);
    }
}
#-----------------------------------------------------------------------------------------


#good way-----------------------------------------------------------------------
#Clasa Library depinde de abstractizări sau interfețe (IBookRepository și IBookSearcher) în loc de implementări concrete. 
#Clasa Library primește instanțe ale acestor interfețe prin constructorul său, ceea ce permite o ușoară substituție a diferitelor implementări.

public class Library
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookSearcher _bookSearcher;

        public Library(IBookRepository bookRepository, IBookSearcher bookSearcher)
        {
            _bookRepository = bookRepository;
            _bookSearcher = bookSearcher;
        }

        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);
        }

        public List<Book> SearchBooks(string query)
        {
            List<Book> books = _bookRepository.GetAllBooks();
            return _bookSearcher.Search(books, query);
        }
    }
#-----------------------------------------------------------------------------------------

 
