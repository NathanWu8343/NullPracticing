namespace NullPracticing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person? p1 = Person.Create("John", "Doe");
            Person? p2 = Person.Create("Tom");
            Person? p3 = null;

            Console.WriteLine($"| {GetLabel(p1)} |");
            Console.WriteLine($"| {GetLabel(p2)} |");
            Console.WriteLine($"| {GetLabel(p3)} |"); // handle null
            Book b1 = Book.Create("C# 9 and .NET 5", p1);
            Book b2 = Book.Create("C# 8 and .NET 4");
            Book b3 = Book.Create("C# 7 and .NET 3");

            Console.WriteLine($"| {GetBookLabel(b1)} |");
            Console.WriteLine($"| {GetBookLabel(b2)} |"); // handle null
            Console.WriteLine($"| {GetBookLabel(b3)} |"); // handle null

            Console.WriteLine($"{b2.Author.LastName}"); // handle null

            var books = new[] { b1, b2, b3 };
            Console.WriteLine(books.Select(x => x.Author.LastName)); // handle null

            Console.ReadLine();

            static string GetBookLabel(Book book)
                => GetLabel(book.Author) is string author
                    ? $"{book.Title} by {author}"
                    : book.Title;
        }

        private static string GetLabel(Person person)
        {
            string name = person.LastName is null
                ? person.FirstName
                : $"{person.FirstName} {person.LastName}";
            return name;
        }

        internal class Person
        {
            public string FirstName { get; }
            public string? LastName { get; }

            private Person(string firstName, string? lastName)
                => (FirstName, LastName) = (firstName, lastName);

            public static Person Create(string firstName, string? lastName)
                => new(firstName, lastName);

            public static Person Create(string firstName)
                => new(firstName, null);
        }

        internal class Book
        {
            public string Title { get; }
            public Person? Author { get; }

            private Book(string title, Person? author)
                => (Title, Author) = (title, author);

            public static Book Create(string title, Person? author)
                => new(title, author);

            public static Book Create(string title)
                => new(title, null);
        }
    }
}