using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;

namespace DAC
{
    
    public class BinaryFormater : IFormater
    {
        string path = "Books.dat";
        public  void Save(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            if (File.Exists(path))
            {
                if (Contains(book)) throw new ArgumentException();
                List<Book> books = GetAll();
                books.Add(book);
                SaveAll(books);
            }
            else
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(book.Author);
                writer.Write(book.Title);
                writer.Write(book.Genre);
                writer.Write(book.YearOfCreating);
            }
        }
       public void SaveAll(List<Book> books)
        {
            if (books == null) throw new ArgumentNullException();
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (var book in books)
                {
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Genre);
                    writer.Write(book.YearOfCreating);
                }
            }
        }
        public void Remove(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            if (Contains(book))
            {
                List<Book> books = GetAll();
                books.Remove(book);
                SaveAll(books);
            }
            else throw new ArgumentException();
        }
       public List<Book> GetByTitle(string Title)
        {
            List<Book> books = new List<Book>();
            books = GetAll();

            return books.Where(x => x.Title == Title).ToList(); ;
        }
      public List<Book> GetByAuthor(string Author)
        {
            List<Book> books = new List<Book>();
            books = GetAll();
            return books.Where(x => x.Author == Author).ToList(); ;
        }
       public List<Book> GetByGenre(string Genre)
        {
            List<Book> books = new List<Book>();
            books = GetAll();
            return books.Where(x => x.Genre == Genre).ToList(); ;
        }
      public  List<Book> GetByYear(int Year)
        {
            List<Book> books = new List<Book>();
            books = GetAll();
            return books.Where(x => x.YearOfCreating
            == Year).ToList(); ;
        }
        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {

                while (reader.PeekChar() > -1)
                {
                    if (reader.PeekChar() != -1)
                    {
                        string Author = reader.ReadString();
                        string Title = reader.ReadString();
                        string Genre = reader.ReadString();
                        int Year = reader.ReadInt32();
                        books.Add(new Book(Author, Title, Genre, Year));
                    }
                }

            }
            return books;
        }
        bool Contains (Book book)
        {
            List<Book> books = GetAll();
            return books.Contains(book); 
        }
    }
       
}
