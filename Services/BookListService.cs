using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAC;

namespace Services
{
    public class BookListService
    {
        List<Book> Books;
        IFormater Formater;
        public BookListService(IFormater formater)
        {
            Formater = formater;
            Books =Formater.GetAll();
        }
        public void AddAll(List<Book> books)
        {
            Formater.SaveAll(books);
        }
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            Formater.Save(book);

        }
        public void RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            Formater.Remove(book);

        }
        public List<Book> FindBookByTag(string value,string Key)
        {
            List<Book> books = new List<Book>();
            switch (Key.ToUpperInvariant())
            {
                case "TITLE":
                    {
                        books=Formater.GetByTitle(value);
                        break;
                    }
                case "AUTHOR":
                    {
                        books = Formater.GetByAuthor(value);
                        break;
                    }
                case "GENRE": 
                    {
                        books = Formater.GetByGenre(value);
                        break;
                    }
                case "YEAR": 
                    {
                        int x;
                        if (!Int32.TryParse(value, out x)) throw new ArgumentException();
                        books = Formater.GetByYear(x);
                        break;
                    }

            }
            return books;
        }
        public List<Book> SortByTag(string Key)
        {
            List<Book> books = new List<Book>();
            switch (Key.ToUpperInvariant())
            {
                case "TITLE":
                    {
                       books=Books.OrderBy(book => book.Title).ToList();
                        break;
                    }
                case "AUTHOR":
                    {
                       books=Books.OrderBy(book => book.Author).ToList();
                        break;
                    }
                    
                case "GENRE":
                    {
                       books= Books.OrderBy(book => book.Genre).ToList();
                        break;
                    }
                case "YEAR":
                    {
                        books=Books.OrderBy(book => book.YearOfCreating).ToList();
                        break;
                    }
                default:
                    {
                      books= Books.OrderBy(book => book.YearOfCreating).ToList();
                        break;
                    }
               

            }
            return books;
        }
        public List<Book> GetAll()
        {

            return Books=Formater.GetAll();
        }
    }
}
