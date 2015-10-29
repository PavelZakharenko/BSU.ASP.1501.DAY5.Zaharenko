using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Book:IComparable<Book>,IEquatable<Book>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int YearOfCreating { get; set; }

        public Book(string author,string title,string genre,int yearOfCreating)
        {
            if ((author == null) || (title == null) || (genre == null)) throw new ArgumentNullException();
            Author = author;
            Title = title;
            Genre = genre;
            YearOfCreating = yearOfCreating;
        }
        public bool Equals(Book book)
        {
            if (ReferenceEquals(null, book)) return false;
            if (ReferenceEquals(this, book)) return true;
            if (book.GetType() != this.GetType()) return false;
            if ((Author == book.Author) && (Title == book.Title) && (Genre == book.Genre) && (YearOfCreating == book.YearOfCreating)) return true;
            return false;
        }
        public int CompareTo(Book book)
        {
            if (ReferenceEquals(null, book)) throw new ArgumentNullException();
            if (ReferenceEquals(this, book)) return 0;
            if (book.GetType() != this.GetType()) throw new ArgumentException();
            if (this.YearOfCreating>book.YearOfCreating)
                return 1;
            if (this.YearOfCreating < book.YearOfCreating)
                return -1;
            else
                return 0;
        }
    }
}
