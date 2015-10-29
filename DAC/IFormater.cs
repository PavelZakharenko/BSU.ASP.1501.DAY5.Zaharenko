using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAC
{
   public interface IFormater
    {
       void Save(Book book);
        void SaveAll(List<Book> books);
        void Remove(Book book);
        List<Book> GetByTitle(string Title);
        List<Book> GetByAuthor(string Author);
        List<Book> GetByGenre(string Genre);
        List<Book> GetByYear(int Year);
        List<Book> GetAll();
    }
}
