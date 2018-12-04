using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class BookSystem
    {
        List<Book> bookList;
        public BookSystem() {
            bookList = new List<Book>();

            AddBook(new Book("Refactoring", "0001", "Martin", true));
            AddBook(new Book("Test Driven Develop", "0002", "Kent Beck", true));
            AddBook(new Book("JUnit", "0003", "Kent Beck", true));
            AddBook(new Book("Programming Patten", "0004", "Jozy", true));
        }
        public void AddBook(Book book) {
            bookList.Add(book);
        }
        public Book FindBookByNumber(string bookNumber) {
            foreach (var book in bookList) {
                if (book.IsBookNumber(bookNumber))
                    return book;
            }
            return null;
        }
        public List<Book> SearchBook(string name) {
            List<Book> list = new List<Book>();
            foreach (var i in bookList) {
                if(i.Name.Contains(name))
                    list.Add(i);
            }
            return list;
        }

        public override string ToString()
        {
            var result = "";
            foreach (var book in bookList)
            {
                result += $"<div>{book}</div>";
            }
            return result;
        }

    }
}
