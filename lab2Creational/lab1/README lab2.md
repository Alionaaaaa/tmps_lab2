lab2 TMPS

#Creational patterns:
- o categorie de modele de design în ingineria software care se ocupă de procesul de creare a obiectelor.
Ele oferă modalități de creare a obiectelor fără a cupla crearea obiectului la clasele de implementare,
promovând astfel flexibilitatea, reutilizabilitatea și ușurința în întreținere.

1) Modelul Singleton
2) Modelul Factory Method
3) Modelul Abstract Factory
4) Modelul Builder
5) Modelul Prototype

#_____Singleton_____
# Def: Se asigură că o clasă are doar o instanță și oferă un punct global de acces la acea instanță.
# Problema rezolvată: Singleton este utilizat în situațiile în care avem nevoie să controlăm accesul
#la un resursă limitată și unde având mai multe instanțe ale resursei ar fi nedorit sau chiar dăunător aplicației.

#GOOD way-----------------------------------------------------------------------------------------

	public class BookRepository : IBookRepository
    {
//Creăm o instanță privată statică
        private static BookRepository _instance; 

//Creăm constructor privat pentru a preveni crearea unei noi instanțe în altă parte a aplicației
        private BookRepository() 
        {
            _books = new List<Book>();
        }

// Creăm o metodă publică statică pentru a obține instanța
        public static BookRepository Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BookRepository();
                }
                return _instance;
            }
        }

        // Methods for managing the BookRepository
    }
#------------------------------------------------------------------------------------------------

#_____Factory Method_____
# Def: Oferă o interfață pentru crearea de obiecte într-o superclasă, dar permite subclaselor să modifice tipul de obiecte care vor fi create.
# Problema rezolvată: Crează obiecte de diferite tipuri printr-o singură metodă
#GOOD way-----------------------------------------------------------------------------------------

Clasa LanguageBookFactory este o clasă care implementează interfața IBookLanguageFactory. 
Metoda CreateBookInEnglish din LanguageBookFactory este suprascrisă și returnează un obiect nou de tipul EnglishBook cu proprietățile specificate. 
Această clasă utilizează Factory Method pentru a crea obiecte diferite de cărți în diferite limbi, în acest caz, pentru a crea cărți în limba engleză și franceză.

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

    public interface IBookLanguageFactory
    {
        Book CreateBookInEnglish(string title, string author, string id);
        Book CreateBookInFrench(string title, string author, string id);
        // alte metode de creare a cărților în diferite limbi
    }

    internal class EnglishBook : Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Id { get; set; }
    }
#------------------------------------------------------------------------------------------------


#_____Abstract Factory_____
# Def: Oferă o interfață pentru crearea de familii de obiecte conexe sau dependente fără a specifica clasele lor concrete.

#GOOD way-----------------------------------------------------------------------------------------
În acest fragment de cod reprezentând o interfață pentru o fabrică de genuri de cărți, putem vedea o implementare a abstract factory pattern.
Interfața este folosită pentru a crea obiecte de genul "Book", dar fără a specifica clasele concrete ale cărților (de exemplu, nu se face referire la o clasă "NovelBook" sau "ShortStoryBook").
În schimb, interfața definește metode pentru a crea cărți de diferite genuri, iar implementările concrete ale acestei interfețe pot furniza obiectele concrete ale cărților.

Astfel, interfața IBookGenreFactory permite crearea de obiecte de tip Book pentru diferite genuri literare, dar fără a specifica clasele concrete ale acestor cărți.
Implementarea acestei interfețe ar putea furniza obiecte concrete de tip "NovelBook" sau "ShortStoryBook", sau orice altă clasă care moștenește clasa "Book" și corespunde cerințelor specifice ale fabricii.


public interface IBookGenreFactory
    {
        Book CreateNovel(string title, string author, string id);
        Book CreateShortStory(string title, string author, string id);
        // alte metode de creare a cărților
    }

public class GenreFactory : IBookGenreFactory { ... }
#------------------------------------------------------------------------------------------------

#_____Builder_____
# Def: Separă construcția unui obiect complex de reprezentarea sa, permițând același proces de construcție să creeze reprezentări diferite.
#GOOD way-----------------------------------------------------------------------------------------
Implementarea pentru patternul builder constă în următoarele elemente:
1)Interfața IBookBuilder - specifică metodele necesare pentru construirea obiectului Book.
2)Clasa EnglishBook - reprezintă obiectul Book pe care îl construim cu ajutorul builder-ului.
3)Clasa EnglishBookBuilder - implementează interfața IBookBuilder și este responsabilă pentru construirea obiectului Book.


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
#------------------------------------------------------------------------------------------------


#_____Prototype_____
# Def: Creează noi obiecte prin clonarea celor existente, evitând costurile suplimentare a creării obiectelor de la zero.

#GOOD way-----------------------------------------------------------------------------------------
public class Novel : Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Id { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }

        public Novel ShallowCopy()                    
        {
            return (Novel)this.MemberwiseClone();
        }
    }

    static void Main(string[] args)
    {
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
#------------------------------------------------------------------------------------------------
