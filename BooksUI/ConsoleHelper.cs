using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Entities;

namespace BooksUI
{
   static class ConsoleHelper
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1.List of books");
            Console.WriteLine("2.Add book.");
            Console.WriteLine("3.Remove book");
            Console.WriteLine("4.Find Book");
            Console.WriteLine("5.Sort books");
            Console.WriteLine("6.Exit");
            Console.WriteLine("Enter number:");
        }
       public static void Display(List<Book> books)
        {
            Console.WriteLine("LIST BOOKS");
            Console.WriteLine("------");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Author} {book.Title} {book.Genre} {book.YearOfCreating}");
                Console.WriteLine("------------");
            }
        }
     public   static void AddBook(BookListService serv)
        {
            Console.WriteLine("ADDING BOOK");
            Console.WriteLine("------");
            Console.WriteLine("Enter Author");
            string Author = Console.ReadLine();
            Console.WriteLine("Enter Title");
            string Title = Console.ReadLine();
            Console.WriteLine("Enter Genre");
            string Genre = Console.ReadLine();
            Console.WriteLine("Enter Year Of Creating");
            int year;
            while (!Int32.TryParse(Console.ReadLine(), out year))
                Console.WriteLine("Enter Year Of Creating");

            serv.AddBook(new Book(Author, Title, Genre, year));
            Console.WriteLine("Book Added");
        }
      public  static void FindBook(BookListService serv)
        {
            Console.WriteLine("Enter Key(Author,Title,Genre,Year):");
            string key = Console.ReadLine();
            Console.WriteLine("Enter Value:");
            string value = Console.ReadLine();
            Display(serv.FindBookByTag(value, key));

        }
      public  static void SortBooks(BookListService serv)
        {
            Console.WriteLine("Enter Key(Author,Title,Genre,Year):");
            string key = Console.ReadLine();
            if (key != String.Empty)
                Display(serv.SortByTag(key));
        }
      public  static void RemoveBook(BookListService serv)
        {
            Console.WriteLine("Enter Author");
            string Author = Console.ReadLine();
            Console.WriteLine("Enter Title");
            string Title = Console.ReadLine();
            Console.WriteLine("Enter Genre");
            string Genre = Console.ReadLine();
            Console.WriteLine("Enter Year Of Creating");
            int year;
            while (!Int32.TryParse(Console.ReadLine(), out year))
                Console.WriteLine("Enter Year Of Creating");
            serv.RemoveBook(new Book(Author, Title, Genre, year));
        }
    }
}
