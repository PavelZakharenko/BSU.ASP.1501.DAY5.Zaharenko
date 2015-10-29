using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Services;
using System.IO;
using DAC;

namespace BooksUI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            BookListService service = new BookListService(new BinaryFormater());
            while(flag)
            {
                ConsoleHelper.DisplayMenu();
                switch(Console.ReadLine())
                {
                    case "1":
                        {
                            ConsoleHelper.Display(service.GetAll());
                            break;
                        }
                    case "2":
                        {
                            ConsoleHelper.AddBook(service);
                            break;
                        }
                    case "3":
                        {
                            ConsoleHelper.RemoveBook(service);
                            break;
                        }
                    case "4":
                        {
                            ConsoleHelper.FindBook(service);
                            break;
                        }
                    case "5":
                        {
                            ConsoleHelper.SortBooks(service);
                            break;
                        }
                    case "6":
                        {
                            flag = false;
                            break;
                        }
                }
            }  
        }
        
    }
}
