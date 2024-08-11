using System;
using System.Linq;

namespace LINQtoObject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Display book title and ISBN
            var booksWithTitleAndIsbn = SampleData.Books
                .Select(book => new { book.Title, book.Isbn });

            foreach (var book in booksWithTitleAndIsbn)
            {
                Console.WriteLine($"Title: {book.Title}, ISBN: {book.Isbn}");
            }

            // Task 2: Display the first 3 books with a price greater than 25
            var priceyBooks = SampleData.Books
                .Where(book => book.Price > 25)
                .Take(3);

            foreach (var book in priceyBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Price: {book.Price}");
            }

            // Task 3: Display book title and publisher name (Method 1)
            var booksWithPublisherMethod1 = SampleData.Books
                .Select(book => new { book.Title, Publisher = book.Publisher.Name });

            foreach (var book in booksWithPublisherMethod1)
            {
                Console.WriteLine($"Title: {book.Title}, Publisher: {book.Publisher}");
            }

            // Task 3: Display book title and publisher name (Method 2)
            var booksWithPublisherMethod2 = from book in SampleData.Books
                                            select new
                                            {
                                                Title = book.Title,
                                                Publisher = book.Publisher.Name
                                            };

            foreach (var book in booksWithPublisherMethod2)
            {
                Console.WriteLine($"Title: {book.Title}, Publisher: {book.Publisher}");
            }

            // Task 4: Find the number of books that cost more than 20
            var numberOfExpensiveBooks = SampleData.Books
                .Count(book => book.Price > 20);

            Console.WriteLine($"Number of books costing more than 20: {numberOfExpensiveBooks}");

            // Task 5: Display book title, price, and subject name sorted by subject name and price
            var sortedBooksList = SampleData.Books
                .OrderBy(book => book.Subject.Name)
                .ThenByDescending(book => book.Price)
                .Select(book => new { book.Title, book.Price, Subject = book.Subject.Name });

            foreach (var book in sortedBooksList)
            {
                Console.WriteLine($"Title: {book.Title}, Price: {book.Price}, Subject: {book.Subject}");
            }

            // Task 6: Display all subjects with books related to each subject
            var subjectsWithBooksList = SampleData.Subjects
                .Select(subject => new
                {
                    SubjectName = subject.Name,
                    Books = SampleData.Books.Where(book => book.Subject.Name == subject.Name)
                });

            foreach (var subject in subjectsWithBooksList)
            {
                Console.WriteLine($"Subject: {subject.SubjectName}");
                foreach (var book in subject.Books)
                {
                    Console.WriteLine($"  - Book: {book.Title}");
                }
            }

            // Task 7: Display book title and price from the GetBooks function
            var booksFromGetBooks = SampleData.GetBooks()
                .Cast<Book>()
                .Select(book => new { book.Title, book.Price });

            foreach (var book in booksFromGetBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Price: {book.Price}");
            }
        }
    }
}
